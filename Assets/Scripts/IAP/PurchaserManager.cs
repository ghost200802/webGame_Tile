﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurchaserManager : MonoBehaviour
{
//     public static PurchaserManager instance;
//     private static IStoreController m_StoreController;          // The Unity Purchasing system.
//     private static IExtensionProvider m_StoreExtensionProvider; // The store-specific Purchasing subsystems.
//
//     // Product identifiers for all products capable of being purchased: 
//     // "convenience" general identifiers for use with Purchasing, and their store-specific identifier 
//     // counterparts for use with and outside of Unity Purchasing. Define store-specific identifiers 
//     // also on each platform's publisher dashboard (iTunes Connect, Google Play Developer Console, etc.)
//
//     // General product identifiers for the consumable, non-consumable, and subscription products.
//     // Use these handles in the code to reference which product to purchase. Also use these values 
//     // when defining the Product Identifiers on the store. Except, for illustration purposes, the 
//     // kProductIDSubscription - it has custom Apple and Google identifiers. We declare their store-
//     // specific mapping to Unity Purchasing's AddProduct, below.
//     public static string kProductIDConsumable = "consumable";
//     public static string kProductIDNonConsumable = "nonconsumable";
//     public static string kProductIDSubscription = "subscription";
//
//     // Apple App Store-specific product identifier for the subscription product.
//     private static string kProductNameAppleSubscription = "com.unity3d.subscription.new";
//
//     // Google Play Store-specific product identifier subscription product.
//     private static string kProductNameGooglePlaySubscription = "com.unity3d.subscription.original";
//
//     private Action<string,IAP_CALLBACK_STATE> PurchaserManager_Callback = delegate (string _iapID, IAP_CALLBACK_STATE _callBackState) { };
//     public static Action InitializeSucceeded;
//     public static event Action RestoreCompleted;
//     public static event Action RestoreFailed;
//     private void Awake()
//     {
//         instance = this;
//         DontDestroyOnLoad(this);
//     }
//     void Start()
//     {
//         // If we haven't set up the Unity Purchasing reference
//         if (m_StoreController == null)
//         {
//             // Begin to configure our connection to Purchasing
//             InitializePurchasing();
//         }
//     }
//
//     public void InitializePurchasing()
//     {
//         // If we have already connected to Purchasing ...
//         if (IsInitialized())
//         {
//             // ... we are done here.
//             return;
//         }
//
//         // Create a builder, first passing in a suite of Unity provided stores.
//         var builder = ConfigurationBuilder.Instance(StandardPurchasingModule.Instance());
//
//         // Add a product to sell / restore by way of its identifier, associating the general identifier
//         // with its store-specific identifiers.
//         //builder.AddProduct(kProductIDConsumable, ProductType.Consumable);
//         //// Continue adding the non-consumable product.
//         //builder.AddProduct(kProductIDNonConsumable, ProductType.NonConsumable);
//         //// And finish adding the subscription product. Notice this uses store-specific IDs, illustrating
//         //// if the Product ID was configured differently between Apple and Google stores. Also note that
//         //// one uses the general kProductIDSubscription handle inside the game - the store-specific IDs 
//         //// must only be referenced here. 
//         //builder.AddProduct(kProductIDSubscription, ProductType.Subscription, new IDs(){
//         //        { kProductNameAppleSubscription, AppleAppStore.Name },
//         //        { kProductNameGooglePlaySubscription, GooglePlay.Name },
//         //    });
//
//
//         //builder.AddProduct(Config.IAP_ID.removeAd.ToString(), ProductType.NonConsumable);
//         foreach (string iapID in Enum.GetNames(typeof(Config.IAP_ID))) {
//             //if (!iapID.Equals(Config.IAP_ID.removeAd))
//             //{
//             //    builder.AddProduct(iapID, ProductType.Consumable);
//             //}
//
//             builder.AddProduct(iapID, ProductType.Consumable);
//         }
//
//
//         // Kick off the remainder of the set-up with an asynchrounous call, passing the configuration 
//         // and this class' instance. Expect a response either in OnInitialized or OnInitializeFailed.
//         UnityPurchasing.Initialize(this, builder);
//     }
//
//
//     public bool IsInitialized()
//     {
// #if UNITY_EDITOR
//         return true;
// #endif
//         // Only say we are initialized if both the Purchasing references are set.
//         return m_StoreController != null && m_StoreExtensionProvider != null;
//     }
//
//
//     public void BuyConsumable()
//     {
//         // Buy the consumable product using its general identifier. Expect a response either 
//         // through ProcessPurchase or OnPurchaseFailed asynchronously.
//         BuyProductID(kProductIDConsumable);
//     }
//
//
//     public void BuyConsumable(Config.IAP_ID iapID, Action<string,IAP_CALLBACK_STATE> _purchaserManager_Callback)
//     {
//         PurchaserManager_Callback = _purchaserManager_Callback;
//         // Buy the consumable product using its general identifier. Expect a response either 
//         // through ProcessPurchase or OnPurchaseFailed asynchronously.
//         BuyProductID(iapID.ToString());
//     }
//
//
//     public void BuyNonConsumable(Config.IAP_ID iapID, Action<string, IAP_CALLBACK_STATE> _purchaserManager_Callback)
//     {
//         PurchaserManager_Callback = _purchaserManager_Callback;
//         // Buy the non-consumable product using its general identifier. Expect a response either 
//         // through ProcessPurchase or OnPurchaseFailed asynchronously.
//         BuyProductID(iapID.ToString());
//     }
//     public void BuyNonConsumable()
//     {
//         // Buy the non-consumable product using its general identifier. Expect a response either 
//         // through ProcessPurchase or OnPurchaseFailed asynchronously.
//         BuyProductID(kProductIDNonConsumable);
//     }
//
//
//     public void BuySubscription()
//     {
//         // Buy the subscription product using its the general identifier. Expect a response either 
//         // through ProcessPurchase or OnPurchaseFailed asynchronously.
//         // Notice how we use the general product identifier in spite of this ID being mapped to
//         // custom store-specific identifiers above.
//         BuyProductID(kProductIDSubscription);
//     }
//
//
//     void BuyProductID(string productId)
//     {
// #if UNITY_EDITOR
//         PurchaserManager_Callback.Invoke(productId, IAP_CALLBACK_STATE.SUCCESS);
// #else
//         // If Purchasing has been initialized ...
//         if (IsInitialized())
//         {
//             // ... look up the Product reference with the general product identifier and the Purchasing 
//             // system's products collection.
//             Product product = m_StoreController.products.WithID(productId);
//
//             // If the look up found a product for this device's store and that product is ready to be sold ... 
//             if (product != null && product.availableToPurchase)
//             {
//                 Debug.Log(string.Format("Purchasing product asychronously: '{0}'", product.definition.id));
//                 // ... buy the product. Expect a response either through ProcessPurchase or OnPurchaseFailed 
//                 // asynchronously.
//                 m_StoreController.InitiatePurchase(product);
//             }
//             // Otherwise ...
//             else
//             {
//                 // ... report the product look-up failure situation  
//                 Debug.Log("BuyProductID: FAIL. Not purchasing product, either is not found or is not available for purchase");
//             }
//         }
//         // Otherwise ...
//         else
//         {
//             // ... report the fact Purchasing has not succeeded initializing yet. Consider waiting longer or 
//             // retrying initiailization.
//             Debug.Log("BuyProductID FAIL. Not initialized.");
//             PurchaserManager_Callback.Invoke(productId, IAP_CALLBACK_STATE.FAIL);
//         }
// #endif
//     }
//
//
//     // Restore purchases previously made by this customer. Some platforms automatically restore purchases, like Google. 
//     // Apple currently requires explicit purchase restoration for IAP, conditionally displaying a password prompt.
//     public void RestorePurchases()
//     {
//         // If Purchasing has not yet been set up ...
//         if (!IsInitialized())
//         {
//             // ... report the situation and stop restoring. Consider either waiting longer, or retrying initialization.
//             Debug.Log("RestorePurchases FAIL. Not initialized.");
//             return;
//         }
//
//         // If we are running on an Apple device ... 
//         if (Application.platform == RuntimePlatform.IPhonePlayer ||
//             Application.platform == RuntimePlatform.OSXPlayer)
//         {
//             // ... begin restoring purchases
//             Debug.Log("RestorePurchases started ...");
//
//             // Fetch the Apple store-specific subsystem.
//             var apple = m_StoreExtensionProvider.GetExtension<IAppleExtensions>();
//             // Begin the asynchronous process of restoring purchases. Expect a confirmation response in 
//             // the Action<bool> below, and ProcessPurchase if there are previously purchased products to restore.
//             apple.RestoreTransactions((result) => {
//                 // The first phase of restoration. If no more responses are received on ProcessPurchase then 
//                 // no purchases are available to be restored.
//                 Debug.Log("RestorePurchases continuing: " + result + ". If no further messages, no purchases available to restore.");
//             });
//         }
//         // Otherwise ...
//         else
//         {
//             // We are not running on an Apple device. No work is necessary to restore purchases.
//             Debug.Log("RestorePurchases FAIL. Not supported on this platform. Current = " + Application.platform);
//         }
//     }
//
//
//     //  
//     // --- IStoreListener
//     //
//
//     public void OnInitialized(IStoreController controller, IExtensionProvider extensions)
//     {
//         // Purchasing has succeeded initializing. Collect our Purchasing references.
//         Debug.Log("OnInitialized: PASS");
//
//         // Overall Purchasing system, configured with products for this application.
//         m_StoreController = controller;
//         // Store specific subsystem, for accessing device-specific store features.
//         m_StoreExtensionProvider = extensions;
//     }
//
//
//     public void OnInitializeFailed(InitializationFailureReason error)
//     {
//         // Purchasing set-up has not succeeded. Check error for reason. Consider sharing this reason with the user.
//         Debug.Log("OnInitializeFailed InitializationFailureReason:" + error);
//     }
//
//     public void OnInitializeFailed(InitializationFailureReason error, string message)
//     {
//         throw new NotImplementedException();
//     }
//
//
//     public PurchaseProcessingResult ProcessPurchase(PurchaseEventArgs args)
//     {
//         //// A consumable product has been purchased by this user.
//         //if (String.Equals(args.purchasedProduct.definition.id, kProductIDConsumable, StringComparison.Ordinal))
//         //{
//         //    Debug.Log(string.Format("ProcessPurchase: PASS. Product: '{0}'", args.purchasedProduct.definition.id));
//         //    // The consumable item has been successfully purchased, add 100 coins to the player's in-game score.
//         //    //ScoreManager.score += 100;
//         //    PurchaserManager_Callback.Invoke(args.purchasedProduct.definition.id);
//         //}
//         //// Or ... a non-consumable product has been purchased by this user.
//         //else if (String.Equals(args.purchasedProduct.definition.id, kProductIDNonConsumable, StringComparison.Ordinal))
//         //{
//         //    Debug.Log(string.Format("ProcessPurchase: PASS. Product: '{0}'", args.purchasedProduct.definition.id));
//         //    // TODO: The non-consumable item has been successfully purchased, grant this item to the player.
//         //}
//         //// Or ... a subscription product has been purchased by this user.
//         //else if (String.Equals(args.purchasedProduct.definition.id, kProductIDSubscription, StringComparison.Ordinal))
//         //{
//         //    Debug.Log(string.Format("ProcessPurchase: PASS. Product: '{0}'", args.purchasedProduct.definition.id));
//         //    // TODO: The subscription item has been successfully purchased, grant this to the player.
//         //}
//         //// Or ... an unknown product has been purchased by this user. Fill in additional products here....
//         //else
//         //{
//         //    Debug.Log(string.Format("ProcessPurchase: FAIL. Unrecognized product: '{0}'", args.purchasedProduct.definition.id));
//         //}
//
//         // Return a flag indicating whether this product has completely been received, or if the application needs 
//         // to be reminded of this purchase at next app launch. Use PurchaseProcessingResult.Pending when still 
//         // saving purchased products to the cloud, and when that save is delayed. 
//         bool validPurchase = true; // Presume valid for platforms with no R.V.
//
//         // Unity IAP's validation logic is only included on these platforms.
// #if UNITY_ANDROID || UNITY_IOS || UNITY_STANDALONE_OSX
//         // Prepare the validator with the secrets we prepared in the Editor
//         // obfuscation window.
//         var validator = new CrossPlatformValidator(GooglePlayTangle.Data(),
//             AppleTangle.Data(), Application.identifier);
//
//         try
//         {
//             // On Google Play, result has a single product ID.
//             // On Apple stores, receipts contain multiple products.
//             var result = validator.Validate(args.purchasedProduct.receipt);
//             // For informational purposes, we list the receipt(s)
//             Debug.Log("Receipt is valid. Contents:");
//             foreach (IPurchaseReceipt productReceipt in result)
//             {
//                 Debug.Log(productReceipt.productID);
//                 Debug.Log(productReceipt.purchaseDate);
//                 Debug.Log(productReceipt.transactionID);
//             }
//         }
//         catch (IAPSecurityException)
//         {
//             Debug.Log("Invalid receipt, not unlocking content");
//             validPurchase = false;
//         }
// #endif
//
//         if (validPurchase)
//         {
//             // Unlock the appropriate content here.
//             PurchaserManager_Callback.Invoke(args.purchasedProduct.definition.id, IAP_CALLBACK_STATE.SUCCESS);
//         }
//         else {
//             PurchaserManager_Callback.Invoke(args.purchasedProduct.definition.id, IAP_CALLBACK_STATE.FAIL);
//         }
//
//         
//         return PurchaseProcessingResult.Complete;
//     }
//
//
//     public void OnPurchaseFailed(Product product, PurchaseFailureReason failureReason)
//     {
//         // A product purchase attempt did not succeed. Check failureReason for more detail. Consider sharing 
//         // this reason with the user to guide their troubleshooting actions.
//         Debug.Log(string.Format("OnPurchaseFailed: FAIL. Product: '{0}', PurchaseFailureReason: {1}", product.definition.storeSpecificId, failureReason));
//         PurchaserManager_Callback.Invoke(product.definition.id, IAP_CALLBACK_STATE.FAIL);
//     }
//
//     public string GetLocalizedPriceString(string iapID)
//     {
// #if UNITY_EDITOR
//         return "0.01$";
// #endif
//         //Debug.Log("GetLocalizedPriceString:"+ iapID);
//         var product = m_StoreController.products.WithID(iapID);
//         //Debug.Log("GetLocalizedPriceString:" + product);
//         //Debug.Log("GetLocalizedPriceString:" + product.metadata.localizedPriceString);
//         if (product != null)
//         {
//             return product.metadata.localizedPriceString;
//         }
//         else
//         {
//             return "0.01$";
//         }
//             
//         
//     }
//     public enum IAP_CALLBACK_STATE
//     {
//         SUCCESS,
//         FAIL
//     }
}
