﻿using Newtonsoft.Json;
using PHWAndriod.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PHWAndriod.Services
{
    public class AppLogic
    {
        public string BaseURL = "https://vijay-test-api.azurewebsites.net/";

        #region ItemTypeMaster
        public async Task<List<ItemTypeModel>> GetItemTypeMasterList()
        {
            List<ItemTypeModel> itemList = new List<ItemTypeModel>();
            try
            {

                using (HttpClient client = new HttpClient())
                {
                    string apiUrl = $"{BaseURL}api/ItemTypeMaster/ItemTypeMasterList";
                    HttpResponseMessage response = await client.GetAsync(apiUrl);

                    if (response.IsSuccessStatusCode && response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string content = await response.Content.ReadAsStringAsync();
                        itemList = JsonConvert.DeserializeObject<List<ItemTypeModel>>(content);
                        return itemList;
                    }
                    else
                        return null;
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex, "AppLogic - GetItemTypeMasterList");
                return null;
            }
        }
        #endregion

        #region MasterMapping
        public async Task<ChildBarcodeDetailModel> GetScanChildBarcodeDetail(string material, string item, string barcode)
        {
            ChildBarcodeDetailModel data = new ChildBarcodeDetailModel();
            try
            {

                using (HttpClient client = new HttpClient())
                {
                    string apiUrl = $"{BaseURL}api/MasterMapping/GetScanChildBarcodeDetail?MaterialType={material}&ItemName={item}&ScanChildBarcode={barcode}";
                    HttpResponseMessage response = await client.GetAsync(apiUrl);

                    if (response.IsSuccessStatusCode && response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string content = await response.Content.ReadAsStringAsync();
                        data = JsonConvert.DeserializeObject<ChildBarcodeDetailModel>(content);
                        return data;
                    }
                    else
                        return null;
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex, "AppLogic - GetScanChildBarcodeDetail");
                return null;
            }
        }

        public async Task<MasterBarcodeDetailModel> GetScanMasterBarcodeDetail(string barcode)
        {
            MasterBarcodeDetailModel data = new MasterBarcodeDetailModel();
            try
            {

                using (HttpClient client = new HttpClient())
                {
                    string apiUrl = $"{BaseURL}api/MasterMapping/GetScanMasterBarcodeDetail?ScanMasterBarcode={barcode}";
                    HttpResponseMessage response = await client.GetAsync(apiUrl);

                    if (response.IsSuccessStatusCode && response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string content = await response.Content.ReadAsStringAsync();
                        data = JsonConvert.DeserializeObject<MasterBarcodeDetailModel>(content);
                        return data;
                    }
                    else
                        return null;
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex, "AppLogic - GetScanMasterBarcodeDetail");
                return null;
            }
        }

        #endregion

        #region PhysicalVerification
        public async Task<PhysicalListModel> GetPhysicalList()
        {
            PhysicalListModel data = new PhysicalListModel();
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string apiUrl = $"{BaseURL}api/PhysicalVerification/getphysicallist";
                    HttpResponseMessage response = await client.GetAsync(apiUrl);

                    if (response.IsSuccessStatusCode && response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string content = await response.Content.ReadAsStringAsync();
                        data = JsonConvert.DeserializeObject<PhysicalListModel>(content);
                        return data;
                    }
                    else
                        return null;
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex, "AppLogic - GetPhysicalList");
                return null;
            }
        }
        public async Task<PhysicalListModel> GetPhysicalListById(int id, string createdBy)
        {
            PhysicalListModel data = new PhysicalListModel();
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string apiUrl = $"{BaseURL}api/PhysicalVerification/getphysicallistbyid?id={id}&CreatedBY={createdBy}";
                    HttpResponseMessage response = await client.GetAsync(apiUrl);

                    if (response.IsSuccessStatusCode && response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string content = await response.Content.ReadAsStringAsync();
                        data = JsonConvert.DeserializeObject<PhysicalListModel>(content);
                        return data;
                    }
                    else
                        return null;
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex, "AppLogic - GetPhysicalListById");
                return null;
            }
        }
        public async Task<PhysicalListModel> AddOperationPhysicalVerify(PhysicalListModel request)
        {
            PhysicalListModel data = new PhysicalListModel();
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string apiUrl = $"{BaseURL}api/PhysicalVerification/addOperationPhysicalVerfiy";

                    string jsonData = JsonConvert.SerializeObject(request);
                    HttpContent requestContent = new StringContent(jsonData, Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await client.PostAsync(apiUrl, requestContent);

                    if (response.IsSuccessStatusCode && response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string content = await response.Content.ReadAsStringAsync();
                        data = JsonConvert.DeserializeObject<PhysicalListModel>(content);
                        return data;
                    }
                    else
                        return null;
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex, "AppLogic - AddOperationPhysicalVerify");
                return null;
            }
        }
        public async Task<PhysicalListModel> UpdateOperationPhysicalVerfiy(PhysicalListModel request)
        {
            PhysicalListModel data = new PhysicalListModel();
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string apiUrl = $"{BaseURL}api/PhysicalVerification/updateOperationPhysicalVerfiy";

                    string jsonData = JsonConvert.SerializeObject(request);
                    HttpContent requestContent = new StringContent(jsonData, Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await client.PutAsync(apiUrl, requestContent);

                    if (response.IsSuccessStatusCode && response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string content = await response.Content.ReadAsStringAsync();
                        data = JsonConvert.DeserializeObject<PhysicalListModel>(content);
                        return data;
                    }
                    else
                        return null;
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex, "AppLogic - UpdateOperationPhysicalVerfiy");
                return null;
            }
        }
        public async Task<bool> DeleteOperationPhysical(int id)
        {
            bool data = false;
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string apiUrl = $"{BaseURL}api/PhysicalVerification/deleteOperationPhysical?Id={id}";

                    HttpResponseMessage response = await client.DeleteAsync(apiUrl);

                    if (response.IsSuccessStatusCode && response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        return data = true;
                    }
                    else
                        return false;
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex, "AppLogic - DeleteOperationPhysical");
                return false;
            }
        }
        #endregion

        #region PickListMaster

        public async Task<List<PickListModel>> PickListMasterList()
        {
            List<PickListModel> itemList = new List<PickListModel>();
            try
            {

                using (HttpClient client = new HttpClient())
                {
                    string apiUrl = $"{BaseURL}PickListMasterList";
                    HttpResponseMessage response = await client.GetAsync(apiUrl);

                    if (response.IsSuccessStatusCode && response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string content = await response.Content.ReadAsStringAsync();
                        itemList = JsonConvert.DeserializeObject<List<PickListModel>>(content);
                        return itemList;
                    }
                    else
                        return null;
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex, "AppLogic - PickListMasterList");
                return null;
            }
        }
        public async Task<List<PickOutProductListModel>> GetPickOutWiseProductList(int pickOutId)
        {
            List<PickOutProductListModel> itemList = new List<PickOutProductListModel>();
            try
            {

                using (HttpClient client = new HttpClient())
                {
                    string apiUrl = $"{BaseURL}GetPickOutWiseProductList?PickOutId={pickOutId}";
                    HttpResponseMessage response = await client.GetAsync(apiUrl);

                    if (response.IsSuccessStatusCode && response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string content = await response.Content.ReadAsStringAsync();
                        itemList = JsonConvert.DeserializeObject<List<PickOutProductListModel>>(content);
                        return itemList;
                    }
                    else
                        return null;
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex, "AppLogic - GetPickOutWiseProductList");
                return null;
            }
        }
        public async Task<List<PickOutProductSpoolModel>> GetPickOutWiseProductWiseSpoolList(int pickOutId, int productId)
        {
            List<PickOutProductSpoolModel> result = new List<PickOutProductSpoolModel>();
            try
            {

                using (HttpClient client = new HttpClient())
                {
                    string apiUrl = $"{BaseURL}GetPickOutWiseProductWiseSpoolList?PickOutId={pickOutId}&ItemId={productId}";
                    HttpResponseMessage response = await client.GetAsync(apiUrl);

                    if (response.IsSuccessStatusCode && response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string content = await response.Content.ReadAsStringAsync();
                        result = JsonConvert.DeserializeObject<List<PickOutProductSpoolModel>>(content);
                        return result;
                    }
                    else
                        return null;
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex, "AppLogic - GetPickOutWiseProductWiseSpoolList");
                return null;
            }
        }
        public async Task<List<PickOutProductSpoolConditionModel>> GetPickOutWiseProductWiseSpoolWiseConditionList(int pickOutId, int productId, int spoolId)
        {
            List<PickOutProductSpoolConditionModel> data = new List<PickOutProductSpoolConditionModel>();
            try
            {

                using (HttpClient client = new HttpClient())
                {
                    string apiUrl = $"{BaseURL}GetPickOutWiseProductWiseSpoolWiseConditionList?PickOutId={pickOutId}&ItemId={productId}&SpoolId={spoolId}";
                    HttpResponseMessage response = await client.GetAsync(apiUrl);

                    if (response.IsSuccessStatusCode && response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string content = await response.Content.ReadAsStringAsync();
                        data = JsonConvert.DeserializeObject<List<PickOutProductSpoolConditionModel>>(content);
                        return data;
                    }
                    else
                        return null;
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex, "AppLogic - GetPickOutWiseProductWiseSpoolWiseConditionList");
                return null;
            }
        }
        public async Task<List<PickOutProductSpoolConditionSizeModel>> GetPickOutWiseProductWiseSpoolWiseConditionWiseSizeList(int pickOutId, int productId, int spoolId, int conditionId)
        {
            List<PickOutProductSpoolConditionSizeModel> data = new List<PickOutProductSpoolConditionSizeModel>();
            try
            {

                using (HttpClient client = new HttpClient())
                {
                    string apiUrl = $"{BaseURL}GetPickOutWiseProductWiseSpoolWiseConditionWiseSizeList?PickOutId={pickOutId}&ItemId={productId}&SpoolId={spoolId}&ConditionId={conditionId}";
                    HttpResponseMessage response = await client.GetAsync(apiUrl);

                    if (response.IsSuccessStatusCode && response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string content = await response.Content.ReadAsStringAsync();
                        data = JsonConvert.DeserializeObject<List<PickOutProductSpoolConditionSizeModel>>(content);
                        return data;
                    }
                    else
                        return null;
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex, "AppLogic - GetPickOutWiseProductWiseSpoolWiseConditionWiseSizeList");
                return null;
            }
        }
        #endregion

        #region StockIn

        public async Task<List<StockInBarcodeDetail>> StockInGetScanBarcodeDetail(int itemTypeId, string scanBarcode)
        {
            List<StockInBarcodeDetail> data = new List<StockInBarcodeDetail>();
            try
            {

                using (HttpClient client = new HttpClient())
                {
                    string apiUrl = $"{BaseURL}api/StockIn/StockIn_GetScanBarcodeDetail?ScanBarcode={scanBarcode}&ItemTypeId={itemTypeId}";
                    HttpResponseMessage response = await client.GetAsync(apiUrl);

                    if (response.IsSuccessStatusCode && response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string content = await response.Content.ReadAsStringAsync();
                        data = JsonConvert.DeserializeObject<List<StockInBarcodeDetail>>(content);
                        return data;
                    }
                    else
                    {
                        await App.Current.MainPage.DisplayAlert("Paramhans Wires", response.ReasonPhrase, "Ok");
                        return null;
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex, "AppLogic - StockInGetScanBarcodeDetail");
                return null;
            }
        }

        public async Task<bool> AddOperationStockInFinalInventory(StockInFinalDetailModel request)
        {
            bool data = false;
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string apiUrl = $"{BaseURL}api/StockIn/addOperationStockIn_FinalInventory";

                    string jsonData = JsonConvert.SerializeObject(request);
                    HttpContent requestContent = new StringContent(jsonData, Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await client.PostAsync(apiUrl, requestContent);

                    if (response.IsSuccessStatusCode && response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex, "AppLogic - AddOperationStockInFinalInventory");
            }
            return data;
        }
        #endregion
    }
}
