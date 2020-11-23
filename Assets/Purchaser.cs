using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Purchasing;


public class Purchaser : MonoBehaviour, IStoreListener
{
    private static IStoreController m_storeController;
    private static IExtensionProvider m_extensionProvider;

    public static Purchaser instance;

    // for product id put in in this region
    private string infinitePuzzles = "infinite_puzzles";
    private string goAdsFree = "go_ads_free";
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
        if (m_storeController == null) { InitializedPurchaseItem(); }
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

        builder.AddProduct(goAdsFree, ProductType.NonConsumable);
        builder.AddProduct(infinitePuzzles, ProductType.Consumable);
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
            SaveLoadData.instance.playerData.eassyGameLeft = 9999;
            SaveLoadData.instance.playerData.mediumGameLeft = 9999;
            SaveLoadData.instance.playerData.hardGameLeft = 9999;
            SaveLoadData.instance.playerData.expertGameLeft = 9999;
            SaveLoadData.instance.playerData.giantGameLeft = 9999;
        }
        else if (String.Equals(args.purchasedProduct.definition.id, goAdsFree, StringComparison.Ordinal))
        {
            Debug.Log("get ads free");
            SaveLoadData.instance.playerData.addFree = "true";
        }
        else if (String.Equals(args.purchasedProduct.definition.id, getSolutions_10, StringComparison.Ordinal))
        {
            Debug.Log("get 10 solutions");
            SaveLoadData.instance.playerData.solutions += 10;
        }
        else if (String.Equals(args.purchasedProduct.definition.id, getInfinityTime_10, StringComparison.Ordinal))
        {
            Debug.Log("get 10 infinite time");
            SaveLoadData.instance.playerData.infinityTimer += 10;
        }
        else if (String.Equals(args.purchasedProduct.definition.id, getInfinityTurn_10, StringComparison.Ordinal))
        {
            Debug.Log("get 10 infinite turn");
            SaveLoadData.instance.playerData.infinityTurn += 10;
        }
        else if (String.Equals(args.purchasedProduct.definition.id, getExploders_10, StringComparison.Ordinal))
        {
            Debug.Log("get 10 exploder");
            SaveLoadData.instance.playerData.exploder += 10;
        }
        else
        {
            Debug.Log("Purchase Failed");
        }

        SaveLoadData.instance.SavingData();
        
        return PurchaseProcessingResult.Complete;
    }



    void BuyProductID(string productID)
    {
        if (IsInitialize())
        {
            Product product = m_storeController.products.WithID(productID);

            if(product != null && product.availableToPurchase)
            {
                Debug.Log(string.Format("Purchasing product asychronously: '{0}'", product.definition.id));
                m_storeController.InitiatePurchase(product);
            }
            else
            {
                Debug.Log("BuyProductID: FAIL. Not purchasing product, either is not found or is not available for purchase");
            }

        }
        else
        {
            Debug.Log("BuyProductID FAIL. Not initialized.");
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