using Cognex.VisionPro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace IntelligentFactory._0._VISION.Parameter
{
    public class Processor_Manager
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="arrayRecipe">
        ///     타겟 Array 레시피
        /// </param>
        /// <param name="image">
        ///     타겟 이미지
        /// </param>
        public void Execute(LibraryManager recipe, CogImage24PlanarColor image)
        {
            Task[] tasks = new Task[recipe.Library.Count];

            // Array 별로 비동기 검사 시작
            for (int i = 0; i < recipe.Library.Count; i++)
            {

                for (int j = 0; j < recipe.Library[j].Count; j++)
                {
                    List<IF_VisionParamObject> logics = recipe.Library[i][j].Logics;

                    //@ Task 사용해서 비동기로 돌릴것
                    Process(logics, image);
                }
            }

            // 모든 Array 검사 종료


            // 결과 처리
        }

        private void Process(List<IF_VisionParamObject> logics, CogImage24PlanarColor image)
        {
            // logics 꺼내서
            for (int i = 0; i < logics.Count; i++)
            {
                switch (logics[i].Type)
                {
                    case "Blob":
                        IF_VisionParam_Blob blobParameter = (IF_VisionParam_Blob)logics[i];
                        //blobParameter.Threshold
                        //blobParameter.ThresholdType
                        
                        //result = cognex.Blob(blobParameter, image);

                        break;
                    case "Pattern":

                        break;
                    case "Color":

                        break;
                    case "EYED":

                        break;
                    case "ML":

                        break;
                }
                
            }

            // Logic + Image 코어 처리

            // 결과 반환
        }
    }
}
