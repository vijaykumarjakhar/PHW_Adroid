﻿using PHWAndriod.Models;
using PHWAndriod.Services;
using System;
using Xamarin.Forms;

namespace PHWAndriod.ViewModels
{
    public class PhysicalVerificationViewModel : BaseViewModel
    {
        #region Properties
        private string barcodeEntry;
        public string BarcodeEntry
        {
            get { return barcodeEntry; }
            set
            {
                barcodeEntry = value;
                OnPropertyChanged(nameof(BarcodeEntry));
            }
        }

        private string productName;
        public string ProductName
        {
            get { return productName; }
            set
            {
                productName = value;
                OnPropertyChanged(nameof(ProductName));
            }
        }

        private int scanCount;
        public int ScanCount
        {
            get { return scanCount; }
            set
            {
                scanCount = value;
                OnPropertyChanged(nameof(ScanCount));
            }
        }

        private string description;
        public string Description
        {
            get { return description; }
            set
            {
                description = value;
                OnPropertyChanged(nameof(Description));
            }
        }

        private string lastScan;
        public string LastScan
        {
            get { return lastScan; }
            set
            {
                lastScan = value;
                OnPropertyChanged(nameof(LastScan));
            }
        }

        private bool isBarcodeLayoutVisible;
        public bool IsBarcodeLayoutVisible
        {
            get { return isBarcodeLayoutVisible; }
            set
            {
                isBarcodeLayoutVisible = value;
                OnPropertyChanged(nameof(IsBarcodeLayoutVisible));
            }
        }

        public Command GetBarcodeDetailCommand { get; }
        public Command ClearCommand { get; }

        AppLogic logic = new AppLogic();
        #endregion

        public PhysicalVerificationViewModel()
        {
            Title = "Physical Verification";
            ClearCommand = new Command(ExecuteClearCommand);
            GetBarcodeDetailCommand = new Command(GetBarcodeDetails);
            ScanCount = 0;
            LastScan = string.Empty;
        }

        private async void GetBarcodeDetails()
        {
            try
            {
                IsBusy = true;
                var result = await logic.GetPhysicalListBarcode(BarcodeEntry);
                if (result != null && result.Count > 0)
                {
                    ProductName = result[0].ItemName;
                    Description = result[0].ItemDescription;
                    foreach (PhysicalListModel model in result)
                    {
                        var finalModel = new PhysicalFinalListModel(model);
                        var response = await logic.AddOperationPhysicalList(finalModel);
                        if (response)
                        {
                            IsBarcodeLayoutVisible = true;
                            ScanCount += 1;
                            LastScan = BarcodeEntry;
                        }
                    }
                }
                else
                {
                    var finalModel = new PhysicalFinalListModel(new PhysicalListModel() { Id = 0, ScanBarcode = BarcodeEntry });
                    var response = await logic.AddOperationPhysicalList(finalModel);
                    if (response)
                    {
                        IsBarcodeLayoutVisible = true;
                        ScanCount += 1;
                        LastScan = BarcodeEntry;
                        ProductName = string.Empty;
                        Description = string.Empty;
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex, "PhysicalVerificationViewModel - GetBarcodeDetails");
            }
            BarcodeEntry = string.Empty;
            IsBusy = false;
            MessagingCenter.Send(this, "PhysicalVerificationFocusBarcodeEntry");
        }

        private async void ExecuteClearCommand(object obj)
        {
            try
            {
                IsBarcodeLayoutVisible = false;
                BarcodeEntry = string.Empty;
                ScanCount = 0;
                LastScan = string.Empty;
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex, "PhysicalVerificationViewModel - ExecuteClearCommand");
            }
        }
    }
}
