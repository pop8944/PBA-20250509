namespace IntelligentFactory
{
    internal class Json_Library
    {
        public string Enabled { get; set; }
        public string Type { get; set; }
        public string GrabIndex { get; set; }
        public string Name { get; set; }
        public string PartName { get; set; }
        public string SamplingCount { get; set; }
        public string Judge_NaisNg { get; set; }

        public string ChkColor { get; set; }
        public string CCoordinate { get; set; }
        public string CMethod { get; set; }
        public string useBinary { get; set; }
        public string isSavePart { get; set; }
        public string MinFoundCount { get; set; }
        public string Condensor_PosType { get; set; }
        public string LC_ReadUse { get; set; }
        public string MasterCount { get; set; }
        //public string LC_Read_MasterCount { get; set; }
        public string UseColorRange { get; set; }
        public string MinScore { get; set; }
        public string Threshold { get; set; }
        public string RangeAreaMin { get; set; }
        public string RangeAreaMax { get; set; }
        //
        public string UseFilter1 { get; set; }
        public string UseFilter2 { get; set; }
        public string Filter1 { get; set; }
        public string Filter1_Kernel_W { get; set; }
        public string Filter1_Kernel_H { get; set; }
        public string Filter2 { get; set; }
        public string Filter2_Kernel_W { get; set; }
        public string Filter2_Kernel_H { get; set; }

        //
        public string Min0 { get; set; }
        public string Min1 { get; set; }
        public string Min2 { get; set; }
        public string Max0 { get; set; }
        public string Max1 { get; set; }
        public string Max2 { get; set; }
        public double Roi_SearchRegion_X { get; set; }
        public double Roi_SearchRegion_Y { get; set; }
        public double Roi_SearchRegion_W { get; set; }
        public double Roi_SearchRegion_H { get; set; }
        public double Roi_DeepLearingRegion_X { get; set; }
        public double Roi_DeepLearingRegion_Y { get; set; }
        public double Roi_DeepLearingRegion_W { get; set; }
        public double Roi_DeepLearingRegion_H { get; set; }
        public double Roi_ColorRegion_X { get; set; }
        public double Roi_ColorRegion_Y { get; set; }
        public double Roi_ColorRegion_W { get; set; }
        public double Roi_ColorRegion_H { get; set; }
    }
}
