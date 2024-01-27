﻿namespace PHWAndriod.Models
{
    public class DispatchFinalDetailModel
    {
        private DispatchBarcodeDetailModel BaseModel;
        private PickListModel PickListModel;
        private BookingDispatchProductDetailListModel BookingDispatchProductDetailListModel;
        private PickOutProductListModel PickOutProductListModel;

        public DispatchFinalDetailModel(DispatchBarcodeDetailModel baseModel, PickListModel pickListModel, BookingDispatchProductDetailListModel bookingDispatchProductDetailListModel,
            PickOutProductListModel pickOutProductListModel)
        {
            this.BaseModel = baseModel;
            this.PickListModel = pickListModel;
            this.BookingDispatchProductDetailListModel = bookingDispatchProductDetailListModel;
            this.PickOutProductListModel = pickOutProductListModel;
        }

        public int Id => 1;
        public string RequisitionNo => PickListModel.PickOutno;
        public int RequisitionId => PickListModel.PickOutId;
        public string Description => BookingDispatchProductDetailListModel.PackType;
        public int ItemId => PickOutProductListModel.ItemId;
        public int RequiredQty => BookingDispatchProductDetailListModel.BoxQty;
        public int IssueQty => 1;
        public string InventoryType => BaseModel.InventoryType;
        public string ItemCode => BaseModel.ItemCode;
        public string ItemName => BaseModel.ItemName;
        public int SpoolId => BaseModel.SpoolId;
        public int GradeId => BaseModel.GradeId;
        public int ConditionId => BaseModel.ConditionId;
        public int SizeId => BaseModel.SizeId;
        public int MachineId => BaseModel.MachineId;
        public double? TareWeight => BaseModel.TareWeight;
        public double? NetWeight => BaseModel.NetWeight;
        public double? GrossWeight => BaseModel.GrossWeight;
        public double? ReGrossWeight => BaseModel.ReGrossWeight;
        public string CoilDia => BaseModel.CoilDia;
        public string LotNo => BaseModel.LotNo;
        public string PalletBarcode => BaseModel.PalletBarcode;
        public string BoxBarcode => BaseModel.BoxBarcode;
        public int SpoolQty => BaseModel.SpoolQty;
        public int BoxQty => BaseModel.BoxQty;
        public int StockOutQty => BookingDispatchProductDetailListModel.OutQty + 1;
        public int CompanyId => 0;
        public int FYId => 0;
        public int VerticalId => 0;
        public int CustomerId => BookingDispatchProductDetailListModel.CustomerId;
    }
}
