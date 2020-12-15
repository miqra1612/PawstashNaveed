using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Purchasing;
using UnityEngine.Purchasing.Security;

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

    public List<string> receiptProductID;

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

    IEnumerator StartLocalChecking()
    {
        yield return new WaitForSeconds(1);
        CheckReceipt();
    }

    bool IsInitialize()
    {
        return m_storeController != null && m_extensionProvider != null;
    }


    public void InitializedPurchaseItem()
    {
        if (IsInitialize())
        {
            SettingManager.sg.DebugText("Already Initialized");
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
        SettingManager.sg.DebugText("Success Initialized IAP");

        StartCoroutine(StartLocalChecking());
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

        //validate purchase here
        
        bool validPurchase = true; // Presume valid for platforms with no R.V.

        // Unity IAP's validation logic is only included on these platforms.
#if UNITY_ANDROID || UNITY_IOS || UNITY_STANDALONE_OSX
        // Prepare the validator with the secrets we prepared in the Editor
        // obfuscation window.
        var validator = new CrossPlatformValidator(GooglePlayTangle.Data(),
            AppleTangle.Data(), Application.identifier);

        try
        {
            // On Google Play, result has a single product ID.
            // On Apple stores, receipts contain multiple products.
            var result = validator.Validate(args.purchasedProduct.receipt);
            // For informational purposes, we list the receipt(s)
            Debug.Log("Receipt is valid. Contents:");
            foreach (IPurchaseReceipt productReceipt in result)
            {
                Debug.Log(productReceipt.productID);
                Debug.Log(productReceipt.purchaseDate);
                Debug.Log(productReceipt.transactionID);

                if (productReceipt.productID == infinitePuzzles)
                {
                    SaveLoadData.instance.playerData.infinitePuzzlePurchaseID = productReceipt.productID;
                    SaveLoadData.instance.playerData.infinitePuzzlePurchaseDate = productReceipt.purchaseDate.ToString();
                }
                else if (productReceipt.productID == goAdsFree)
                {
                    SaveLoadData.instance.playerData.adsFreePurchaseID = productReceipt.productID;
                    SaveLoadData.instance.playerData.adsFreePurchaseDate = productReceipt.purchaseDate.ToString();
                }
            }
        }
        catch (IAPSecurityException)
        {
            Debug.Log("Invalid receipt, not unlocking content");
            validPurchase = false;
        }
#endif

        if (validPurchase)
        {
            // Unlock the appropriate content here.
            SettingManager.sg.DebugText("valid purchased");
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
    
    public void CheckReceipt()
    {
        if(Application.platform == RuntimePlatform.Android)
        {
            DateTime puzzleDate = DateTime.Parse(SaveLoadData.instance.playerData.infinitePuzzlePurchaseDate);
            DateTime adsFreeDate = DateTime.Parse(SaveLoadData.instance.playerData.adsFreePurchaseDate);

            int result1 = 60;
            int result2 = 60;

            if(SaveLoadData.instance.playerData.infinitePuzzlePurchaseDate != "")
            {
                result1 = DateTime.Compare(puzzleDate, System.DateTime.Now);
            }
           
            if(SaveLoadData.instance.playerData.adsFreePurchaseDate != "")
            {
                result2 = DateTime.Compare(adsFreeDate, System.DateTime.Now);
            }
           

            if (result1 <= 30)
            {
                SaveLoadData.instance.playerData.infinitePuzzle = "true";
                SettingManager.sg.DebugText("receipt checked infinite puzzle");
            }
            else
            {
                SaveLoadData.instance.playerData.infinitePuzzle = "false";
            }

            if (result2 <= 30)
            {
                SaveLoadData.instance.playerData.addFree = "true";
                SettingManager.sg.DebugText("receipt checked ads free");
            }
            else
            {
                SaveLoadData.instance.playerData.addFree = "false";
            }
        }
       


        /*
        Product product = m_storeController.products.WithID(infinitePuzzles);

        if(product != null && product.hasReceipt)
        {
            SaveLoadData.instance.playerData.infinitePuzzle = "true";
            SettingManager.sg.DebugText("receipt checked infinite puzzle");
        }
        else
        {
            SaveLoadData.instance.playerData.infinitePuzzle = "false";
        }

        Product adsfree = m_storeController.products.WithID(goAdsFree);

        if (adsfree != null && product.hasReceipt)
        {
            SaveLoadData.instance.playerData.addFree = "true";
            SettingManager.sg.DebugText("receipt checked ads free");
        }
        else
        {
            SaveLoadData.instance.playerData.addFree = "false";
        }
        */
        
    }
}