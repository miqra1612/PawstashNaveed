using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Purchasing;


public class Purchaser : MonoBehaviour, IStoreListener
{
    private static IStoreController m_storeController;
    private static IExtensionProvider m_extensionProvider;

    public static Purchaser instance;

    // for product id put in in this region
    private string infinitePuzzles = "buy_infinite_puzzle";
    private string goAdsFree = "get_free_ads";
    private string getSolutions_10 = "10_solutions";
    private string getInfinityTime_10 = "10_infinity_timers";
    private string getInfinityTurn_10 = "10_infinity_moves";
    private string getExploders_10 = "10_exploders";


    // end region

    private void Awake()
    {
        instance = this;    
    }

    void Start()
    {
        if (m_storeController == null)
        {
            InitializedPurchaseItem();
        }
    }

    bool IsInitialize()
    {
        return m_storeController != null && m_extensionProvider != null;
    }


    public void InitializedPurchaseItem()
    {
        if (IsInitialize())
        {
            return;
        }

        var builder = ConfigurationBuilder.Instance(StandardPurchasingModule.Instance());

        //define consumable product or not

        builder.AddProduct(goAdsFree, ProductType.Subscription);
        builder.AddProduct(infinitePuzzles, ProductType.Subscription);
        builder.AddProduct(getExploders_10, ProductType.Consumable);
        builder.AddProduct(getInfinityTime_10, ProductType.Consumable);
        builder.AddProduct(getSolutions_10, ProductType.Consumable);
        builder.AddProduct(getInfinityTurn_10, ProductType.Consumable);

        UnityPurchasing.Initialize(this, builder);
    }

    public void BuyInfinitePuzzle()
    {
        BuyProductID(infinitePuzzles);
    }

    public void BuyGoFreeAds()
    {
        BuyProductID(goAdsFree);
    }

    public void BuySolution()
    {
        BuyProductID(getSolutions_10);
    }

    public void BuyInfiniteTurn()
    {
        BuyProductID(getInfinityTurn_10);
    }

    public void BuyInfiniteTime()
    {
        BuyProductID(getInfinityTime_10);
    }

    public void BuyExploder()
    {
        BuyProductID(getExploders_10);
    }

    public void OnInitialized(IStoreController controller, IExtensionProvider extensions)
    {
        Debug.Log("Store init");
        
        m_storeController = controller;
        m_extensionProvider = extensions;
    }

    public void OnInitializeFailed(InitializationFailureReason error)
    {
        Debug.Log("store init failed");
        SettingManager.sg.DebugText("Fail to initialize IAP");
        StartCoroutine(RetryInit());
        
    }

    public void OnPurchaseFailed(Product i, PurchaseFailureReason p)
    {
        Debug.Log("purchase failed");
    }

    public PurchaseProcessingResult ProcessPurchase(PurchaseEventArgs args)
    {
        if (String.Equals(args.purchasedProduct.definition.id, infinitePuzzles, StringComparison.Ordinal))
        {
            Debug.Log("get infinite Puzzle");
            SettingManager.sg.DebugText("get 30 days infinite puzzle");
            SaveLoadData.instance.playerData.infinitePuzzle = "true";
            
        }
        else if (String.Equals(args.purchasedProduct.definition.id, goAdsFree, StringComparison.Ordinal))
        {
            Debug.Log("get ads free");
            SettingManager.sg.DebugText("get 30 days ads free");
            SaveLoadData.instance.playerData.addFree = "true";
        }
        else if (String.Equals(args.purchasedProduct.definition.id, getSolutions_10, StringComparison.Ordinal))
        {
            Debug.Log("get 10 solutions");
            SettingManager.sg.DebugText("get 10 solusion");
            SaveLoadData.instance.playerData.solutions += 10;
        }
        else if (String.Equals(args.purchasedProduct.definition.id, getInfinityTime_10, StringComparison.Ordinal))
        {
            Debug.Log("get 10 infinite time");
            SettingManager.sg.DebugText("get 10 infinite time");
            SaveLoadData.instance.playerData.infinityTimer += 10;
        }
        else if (String.Equals(args.purchasedProduct.definition.id, getInfinityTurn_10, StringComparison.Ordinal))
        {
            Debug.Log("get 10 infinite turn");
            SettingManager.sg.DebugText("get 10 infinite turn");
            SaveLoadData.instance.playerData.infinityTurn += 10;
        }
        else if (String.Equals(args.purchasedProduct.definition.id, getExploders_10, StringComparison.Ordinal))
        {
            Debug.Log("get 10 exploder");
            SettingManager.sg.DebugText("get 10 exploder");
            SaveLoadData.instance.playerData.exploder += 10;
        }
        else
        {
            Debug.Log("Purchase Failed");
            SettingManager.sg.DebugText("fail to purchase");
        }

        SaveLoadData.instance.SavingData();
        
        return PurchaseProcessingResult.Complete;
    }

    IEnumerator RetryInit()
    {
        yield return new WaitForSeconds(1);
        SettingManager.sg.DebugText("Retry initialize IAP");
        InitializedPurchaseItem();
    }

    void BuyProductID(string productID)
    {
        if (IsInitialize())
        {
            Product product = m_storeController.products.WithID(productID);

            if(product != null && product.availableToPurchase)
            {
                Debug.Log(string.Format("Purchasing product asychronously: '{0}'", product.definition.id));
                SettingManager.sg.DebugText("purchase product: " + product.definition.id);
                m_storeController.InitiatePurchase(product);
            }
            else
            {
                Debug.Log("BuyProductID: FAIL. Not purchasing product, either is not found or is not available for purchase");
                SettingManager.sg.DebugText("Fail purchase product: " + product.definition.id);
            }

        }
        else
        {
            Debug.Log("BuyProductID FAIL. Not initialized.");
            SettingManager.sg.DebugText("fail to initialize");
        }
    }

    public void RestorePurchases()
    {
        if (!IsInitialize())
        {
            Debug.Log("RestorePurchases FAIL. Not initialized.");

            return;
        }

        if (Application.platform == RuntimePlatform.IPhonePlayer ||
            Application.platform == RuntimePlatform.OSXPlayer)
        {
            Debug.Log("RestorePurchases started ...");

            var apple = m_extensionProvider.GetExtension<IAppleExtensions>();
            apple.RestoreTransactions((result) => {
                Debug.Log("RestorePurchases continuing: " + result + ". If no further messages, no purchases available to restore.");
            });
        }
        else
        {
            Debug.Log("RestorePurchases FAIL. Not supported on this platform. Current = " + Application.platform);
        }
    }
}