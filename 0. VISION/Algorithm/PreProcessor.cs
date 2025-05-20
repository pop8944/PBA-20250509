using IntelligentFactory._0._VISION.Parameter;
using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntelligentFactory._0._VISION.Algorithm
{
    public static class PreProcessor
    {
        /// <summary>
        /// 이진화
        /// </summary>
        /// <param name="image"> 대상 이미지 </param>
        /// <param name="thresholdValue"> 이진화 임계값 </param>
        /// <returns> 이진화된 이미지 </returns>
        public static Mat ApplyThreshold(Mat image, double thresholdValue,double thresholdMax, bool inv)
        {
            Mat result = new Mat();
            if (inv)
                Cv2.Threshold(image, result, thresholdValue, thresholdMax, ThresholdTypes.BinaryInv);
            else
                Cv2.Threshold(image, result, thresholdValue, thresholdMax, ThresholdTypes.Binary);
            return result;
        }

        /// <summary>
        /// 모폴로지
        /// </summary>
        /// <param name="image"> 대상 이미지 </param>
        /// <param name="types"> 
        ///     Erode (침식) - 객체를 축소 / 작은 노이즈 제거 (노이즈 제거)
        ///     Dilation (팽창) - 객체를 확대 / 끊어진 영역 연결 (구멍 채우기)
        ///     Open (열림) - 침식 후 팽창 / 배경과 연결되지 않은 작은 흰 점 제거 (노이즈 제거)
        ///     Close (닫힘) - 팽창 후 침식 / 글자 내부의 작은 검은 점 제거 (구멍 매우기)
        ///     Gradient - 팽창 - 침식 / 객체 경계 검출 (엣지 강조)
        ///     Tophat - 원본 - 열림 (밝은 영역 강조)
        ///     Blackhat - 닫힘 - 원본 (어두운 영역 강조)
        /// </param>
        /// <param name="ksize"> 커널 사이즈 </param>
        /// <returns> 모폴로지가 적용된 이미지 </returns>
        public static Mat ApplyMorphology(Mat image, MorphTypes types, int ksize = 3, Point? anchor = null, int iterations = 1)
        {
            Mat result = new Mat();
            var kernel = Cv2.GetStructuringElement(MorphShapes.Rect, new Size(ksize, ksize));
            Cv2.MorphologyEx(image, result, types, kernel, anchor, iterations);

            return result;
        }

        /// <summary>
        /// 메디안 필터
        /// - 중앙값을 이용해 노이즈를 제거. 주로 점 노이즈 제거에 사용
        /// </summary>
        /// <param name="image"> 대상 이미지 </param>
        /// <param name="ksize"> 커널 사이즈 </param>
        /// <returns> 메디안 필터가 적용된 이미지 </returns>
        public static Mat ApplyMedianFilter(Mat image, int ksize)
        {
            Mat result = new Mat();
            Cv2.MedianBlur(image, result, ksize);
            return result;
        }

        /// <summary>
        /// 방향성 엣지 검출 (1차 미분 연산)
        /// 경계 검출뿐만 아니라 이미지의 특징을 분석할 때도 유용하게 사용됨
        /// xorder = 1, yorder = 0 => 수직 방향 경계 검출 ( 가로 엣지 )
        /// xorder = 0, yorder = 1 => 수평 방향 경계 검출 ( 세로 엣지 )
        /// xorder = 1, yorder = 1 => 대각선 경계 검출
        /// ksize를 1로 설정시 Scharr 필터 적용으로 더 정밀한 결과 출력됨
        /// </summary>
        /// <param name="image"></param>
        /// <param name="ksize"></param>
        /// <returns></returns>
        public static Mat ApplySobelFilter(Mat image, MatType type, int xorder, int yorder, int ksize = 3, double scale = 1, double delta = 0, BorderTypes borderType = BorderTypes.Default)
        {
            Mat result = new Mat();
            Cv2.Sobel(image, result, type, xorder, yorder, ksize, scale, delta, borderType);
            Cv2.ConvertScaleAbs(result, result);
            return result;
        }

        /// <summary>
        /// 가우시안 블러
        /// - 가우시안 분포를 이용해 노이즈를 줄이고 이미지를 부드럽게
        /// </summary>
        /// <param name="image"> 대상 이미지 </param>
        /// <param name="ksize"> 커널 사이즈 </param>
        /// <param name="sigmaX"> 가우시안 커널의 표준편차값. 클수록 블러 효과 강함 </param>
        /// <returns> 가우시안 블러가 적용된 이미지 </returns>
        public static Mat ApplyGaussianBlur(Mat image, Size ksize/*5,5*/, double sigmaX = 1.5)
        {
            Mat result = new Mat();
            Cv2.GaussianBlur(image, result, ksize, sigmaX);
            return result;
        }

        /// <summary>
        /// 라플라시안 필터
        /// - 이미지의 Edge를 강조하고 선명도를 높이는데 사용
        /// 
        /// 2차 미분 연산 ( 모든 방향 엣지 강조 )
        /// </summary>
        /// <param name="image"> 대상 이미지 </param>
        /// <param name="ksize"> 커널 사이즈 </param>
        /// <returns> 라플라시안 필터가 적용된 이미지 </returns>
        public static Mat ApplyLaplacian(Mat image, int ksize = 1, double scale = 1, double delta = 0, BorderTypes borderType = BorderTypes.Default)
        {
            Mat result = new Mat();
            Cv2.Laplacian(image, result, MatType.CV_64F, ksize, scale, delta, borderType);
            Cv2.ConvertScaleAbs(result, result);
            return result;
        }

        /// <summary>
        /// 바이래털 필터
        /// - 색과 공간을 모두 고려한 블러링 처리. 노이즈를 제거하면서 가장자리 부분을 잘 보존함.
        /// </summary>
        /// <param name="image"> 대상 이미지 </param>
        /// <param name="d"> 필터 직경. 크면 더 많은 픽셀을 고려해서 필터링. 0이면 sigmaSpace에 비례하여 자동 결정 </param>
        /// <param name="sigmaColor"> 색공간에서의 시그마 값. 크면 더 많은 색을 고려해 블러링되고 평활화됨. </param>
        /// <param name="sigmaSpace"> 공간적 시그마 값. 크면 더 멀리 있는 픽셀을 고려해 블러링되고 평활화됨. </param>
        /// <returns> 이중 필터가 적용된 이미지 </returns>
        public static Mat ApplyBilateralFilter(Mat image, int d = 9, double sigmaColor = 75, double sigmaSpace = 75)
        {
            Mat result = new Mat();
            Cv2.BilateralFilter(image, result, d, sigmaColor, sigmaSpace);
            return result;

        }

        /// <summary>
        /// 소벨 + 히스테리시스 임계값으로 노이즈에 강함
        /// </summary>
        /// <param name="image"></param>
        /// <param name="lowThreshold"></param>
        /// <param name="highThreshold"></param>
        /// <param name="apertureSize"></param>
        /// <param name="l2Gradient"></param>
        /// <returns></returns>
        public static Mat ApplyCannyFilter(Mat image, double lowThreshold, double highThreshold, int apertureSize = 3, bool l2Gradient = false)
        {
            Mat result = new Mat();
            Cv2.Canny(image, result, lowThreshold, highThreshold, apertureSize, l2Gradient);
            return result;
        }

        public static Mat ApplyDFT(Mat image, DftFlags flag = DftFlags.None, int nonZeroRows = 0)
        {
            Mat result = new Mat();
            Cv2.Dft(image, result, flag, nonZeroRows);
            return result;
        }

        /// <summary>
        /// 클레이히 필터
        /// - 대비값을 최대로 올려주는 필터
        /// </summary>
        /// <param name="image"> 대상 이미지 </param>
        /// <param name="clipLimit"> 히스토그램 균등화 제한값. </param>
        /// <param name="tileGridSize"> 적용될 타일의 크기 정의. 작으면 지역적으인 대비를 더 잘 살리고, 크면 전체적인 대비를 증가시킴. </param>
        /// <returns></returns>
        public static Mat ApplyCLAHE(Mat image, Size tileGridSize/*8,8*/, double clipLimit = 2.0)
        {
            Mat result = new Mat();
            var clahe = Cv2.CreateCLAHE(clipLimit, tileGridSize);
            clahe.Apply(image, result);
            return result;
        }

        /// <summary>
        /// 이미지 리사이징을 수행
        /// </summary>
        /// <param name="image"> 원본 이미지 </param>
        /// <param name="size"> 출력 이미지 크기 / 0,0이면 fx,fy 사용 </param>
        /// <param name="fx"> 가로 크기 비율 </param>
        /// <param name="fy"> 세로 크기 비율 </param>
        /// <param name="interpolationFlags"> 
        /// 보간법 방식 
        /// - NEAREST : 가장 가까운 픽셀 사용 ( 속도 빠름, 품질 낮음)
        /// - LINEAR : 2*2 픽셀 평균 사용 ( 기본값, 속도-품질 균형)
        /// - CUBIC : 4*4 픽셀 보간 ( 부드러움 )
        /// - LANCZ054 : 8*8 픽셀 보간 ( 선명함 )
        /// </param>
        /// <returns></returns>
        public static Mat ApplyResize(Mat image, Size size, double fx = 0, double fy = 0, InterpolationFlags interpolationFlags = InterpolationFlags.Linear)
        {
            Mat result = new Mat();
            Cv2.Resize(image, result, size, fx, fy, interpolationFlags);
            return result;
        }

        public static Mat ApplyGammaCorrection(Mat image)
        {
            Mat result = new Mat();
            image.ConvertTo(result, -1, 1, 0);
            return result;
        }

        public static Mat ApplyEqualization(Mat image)
        {
            Mat result = new Mat();
            Cv2.EqualizeHist(image, result);
            return result;
        }



        public static Mat ApplyGrayscale(Mat image, ColorConversionCodes colorConversionCodes, int dstCn = 0)
        {
            Mat result = new Mat();
            // CvtColor는 이미지의 색상공간을 변환할때 사용
            // BGR -> Grayscale, BGR -> HSV
            Cv2.CvtColor(image, result, colorConversionCodes, dstCn);
            return result;
        }

        /// <summary>
        /// 원근 변환을 수행하기위한 변환 행렬(3*3)을 계산하는 함수
        /// 사다리꼴 모양의 이미지를 직사각형으로 변환하거나, 시점을 변경할 수 있음.
        /// 코너 좌표는 4개여야 한다. (좌상, 우상, 좌하, 우하)
        /// 출력 사이즈는 dstPoints의 좌표와 맞춰줘야 한다.
        /// </summary>
        /// <param name="image"></param>
        /// <returns></returns>
        public static Mat ApplyPerspectiveTransform(Mat image, Point2f[] srcPoints, Point2f[] dstPoints, Size size)
        {
            Mat result = new Mat();
            Mat matrix = Cv2.GetPerspectiveTransform(srcPoints, dstPoints);
            Cv2.WarpPerspective(image, result, matrix, size);
            return result;
        }

        /// <summary>
        /// 아핀변환을 적용하여 이미지를 이동, 회전, 확대/축소, 기울이는 등의 변형을 할 수 있음
        /// 아핀 변환은 직선성을 유지하면서 변형하는 방식으로, 변환 후에도 직선이 직선으로 유지됨
        /// 아핀변환은 2*3 행렬을 사용하여 수행
        /// x' |x축 확대, x축 기울이기, x축 이동|
        /// y' |y축 확대, y축 기울이기, y축 이동|
        /// </summary>
        /// <returns></returns>
        public static Mat ApplyAffine(Mat image, double scaleX, double shearingX, double translationX, double scaleY, double shearingY, double translationY)
        {
            Mat result = new Mat();

            // 2*3 아핀 행렬 생성
            Mat matrix = new Mat(2, 3, MatType.CV_32F);
            //matrix.SetArray(0, 0, scaleX, shearingX, translationX);
            //matrix.SetArray(1, 0, scaleY, shearingY, translationY);

            Cv2.WarpAffine(image, result, matrix, image.Size());

            return result;
        }

        /// <summary>
        /// 컬러 이미지를 채널별로 분리하는 함수
        /// B, G, R 순서
        /// </summary>
        /// <param name="image"></param>
        /// <returns></returns>
        public static Mat[] ApplySplit(Mat image)
        {
            return Cv2.Split(image);
        }

        /// <summary>
        /// 특정 색상 채널 추출 수행
        /// 0 => Blue
        /// 1 => Green
        /// 2 => Red
        /// </summary>
        /// <param name="image"></param>
        /// <param name="channelNumber"></param>
        /// <returns></returns>
        public static Mat ApplyExtractColorChannel(Mat image, int channelNumber)
        {
            Mat[] channels = ApplySplit(image);
            Mat zero = Mat.Zeros(image.Size(), MatType.CV_8UC1);
            Mat result = new Mat();
            switch (channelNumber)
            {
                case 0:
                    Cv2.Merge(new Mat[] { channels[0], zero, zero }, result);
                    break;

                case 1:
                    Cv2.Merge(new Mat[] { zero, channels[1], zero }, result);
                    break;

                case 2:
                    Cv2.Merge(new Mat[] { zero, zero, channels[2] }, result);
                    break;
            }

            return result;
        }

        public static Mat ApplyColor(Mat image, ColorConversionCodes colorCode, int dstCn)
        {
            Mat result = new Mat();
            Cv2.CvtColor(image, result, colorCode/*ColorConversionCodes.BGR2GRAY*/, dstCn);
            return result;
        }

        /// <summary>
        /// Cv2.Split으로 분리된 채널을 하나의 이미지로 병합 수행
        /// </summary>
        /// <param name="channels"></param>
        /// <returns></returns>
        public static Mat ApplyMerge(Mat[] channels)
        {
            Mat result = new Mat();
            Cv2.Merge(channels, result);
            return result;
        }

        /// <summary>
        /// 컬러이미지 체크 수행
        /// </summary>
        /// <param name="image"></param>
        /// <returns></returns>
        public static bool IsColorImage(Mat image)
        {
            return image.Channels() == 3;
        }

        /// <summary>
        /// 이미지 저장
        /// </summary>
        /// <param name="image"> 대상 이미지 </param>
        /// <param name="savePath"> 저장 경로 </param>
        public static void SaveResult(Mat image, string savePath)
        {
            Cv2.ImWrite(savePath, image);
        }

        public static Mat ExecutePreProcessing(Mat image, IF_VisionParamObject logic)
        {
            Mat resultImage = new Mat();
            for (int i = 0; i < logic.ImgProcessingList.Count; i++)
            {
                switch (logic.ImgProcessingList[i.ToString()].Type)
                {
                    case ImageProcessingMethod.Binarization:
                        {
                            IF_VisionParam_Binarization binarization = logic.ImgProcessingList[i.ToString()] as IF_VisionParam_Binarization;
                            image.SaveImage("E:\test.bmp");
                            image = ApplyThreshold(image, binarization.ThresholdValue, binarization.MaxValue, binarization.ThresholdType);
                            break;
                        }
                    case ImageProcessingMethod.Morphology:
                        {
                            IF_VisionParam_Morphology morphology = logic.ImgProcessingList[i.ToString()] as IF_VisionParam_Morphology;
                            image = ApplyMorphology(image, morphology.MorphType, morphology.KernerSize, new OpenCvSharp.Point(morphology.PointX, morphology.PointY), morphology.Iterations);
                            break;
                        }
                    case ImageProcessingMethod.MedianFilter:
                        {
                            IF_VisionParam_MedianBlur medianBlur = logic.ImgProcessingList[i.ToString()] as IF_VisionParam_MedianBlur;
                            image = ApplyMedianFilter(image, medianBlur.KernerSize);
                            break;
                        }
                    case ImageProcessingMethod.SobelFilter:
                        {
                            IF_VisionParam_SobelFilter sobelFilter = logic.ImgProcessingList[i.ToString()] as IF_VisionParam_SobelFilter;
                            image = ApplySobelFilter(image, sobelFilter.MatType, sobelFilter.OrderX, sobelFilter.OrderY, sobelFilter.KernerSize, sobelFilter.Scale, sobelFilter.Delta, sobelFilter.BorderType);
                            break;
                        }
                    case ImageProcessingMethod.CannyFilter:
                        {
                            IF_VisionParam_CannyFilter cannyFilter = logic.ImgProcessingList[i.ToString()] as IF_VisionParam_CannyFilter;
                            image = ApplyCannyFilter(image, cannyFilter.LowThreshold, cannyFilter.HighThreshold, cannyFilter.ApertureSize, cannyFilter.L2Gradient);
                            break;
                        }
                    case ImageProcessingMethod.GaussianBlur:
                        {
                            IF_VisionParam_GaussianBlur gaussianBlur = logic.ImgProcessingList[i.ToString()] as IF_VisionParam_GaussianBlur;
                            image = ApplyGaussianBlur(image, new OpenCvSharp.Size(gaussianBlur.KernerSizeX, gaussianBlur.KernerSizeY), gaussianBlur.SigmaX);
                            break;
                        }
                    case ImageProcessingMethod.Laplacian:
                        {
                            IF_VisionParam_LaplacialFilter laplacian = logic.ImgProcessingList[i.ToString()] as IF_VisionParam_LaplacialFilter;
                            image = ApplyLaplacian(image, laplacian.KernerSize, laplacian.Scale, laplacian.Delta, laplacian.BorderType);
                            break;
                        }
                    case ImageProcessingMethod.GammaCorrection:
                        {
                            IF_VisionParam_GammaCorrection gammaCorrection = logic.ImgProcessingList[i.ToString()] as IF_VisionParam_GammaCorrection;
                            image = ApplyGammaCorrection(image);
                            break;
                        }
                    case ImageProcessingMethod.Equalization:
                        {
                            IF_VisionParam_Equalization equalization = logic.ImgProcessingList[i.ToString()] as IF_VisionParam_Equalization;
                            image = ApplyEqualization(image);
                            break;
                        }
                    case ImageProcessingMethod.PerspectiveTransform:
                        {
                            IF_VisionParam_Perspective perspective = logic.ImgProcessingList[i.ToString()] as IF_VisionParam_Perspective;
                            Point2f[] SrcPoint = new Point2f[]
                            {
                                                new Point2f(perspective.SrcPointLT, perspective.SrcPointRT),
                                                new Point2f(perspective.SrcPointLB, perspective.SrcPointRB)
                            };
                            Point2f[] DstPoint = new Point2f[]
                            {
                                                new Point2f(perspective.DstPointLT, perspective.DstPointRT),
                                                new Point2f(perspective.DstPointLB, perspective.DstPointRB)
                            };
                            image = ApplyPerspectiveTransform(image, SrcPoint, DstPoint, new OpenCvSharp.Size(perspective.DstSizeX, perspective.DstSizeY));
                            break;
                        }
                    case ImageProcessingMethod.Affine:
                        {
                            IF_VisionParam_Affine affine = logic.ImgProcessingList[i.ToString()] as IF_VisionParam_Affine;
                            image = ApplyAffine(image, affine.ScaleX, affine.TranslationX, affine.TranslationX, affine.ScaleY, affine.ShearingY, affine.TranslationY);
                            break;
                        }
                    case ImageProcessingMethod.DFT:
                        {
                            IF_VisionParam_DFT dft = logic.ImgProcessingList[i.ToString()] as IF_VisionParam_DFT;
                            image = ApplyDFT(image, dft.Flag, dft.NonzeroRows);
                            break;
                        }
                    case ImageProcessingMethod.ExtractColorChannel:
                        {
                            IF_VisionParam_ExtractColorChannel extractColorChannel = logic.ImgProcessingList[i.ToString()] as IF_VisionParam_ExtractColorChannel;
                            image = ApplyExtractColorChannel(image, extractColorChannel.Number);
                            break;
                        }
                    case ImageProcessingMethod.ColorConversion:
                        {
                            IF_VisionParam_Color colorConversion = logic.ImgProcessingList[i.ToString()] as IF_VisionParam_Color;
                            image = ApplyColor(image, colorConversion.CCC, colorConversion.DstCn);
                            break;
                        }
                }
            }
            resultImage = image.Clone();
            return resultImage;
        }
    }
}
