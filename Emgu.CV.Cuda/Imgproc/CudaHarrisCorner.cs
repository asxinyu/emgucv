﻿//----------------------------------------------------------------------------
//  Copyright (C) 2004-2013 by EMGU. All rights reserved.       
//----------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.Util;

namespace Emgu.CV.Cuda
{

   /// <summary>
   /// Runs the Harris edge detector on image. Similarly to cvCornerMinEigenVal and cvCornerEigenValsAndVecs, for each pixel it calculates 2x2 gradient covariation matrix M over block_size x block_size neighborhood. Then, it stores
   /// det(M) - k*trace(M)^2
   /// to the destination image. Corners in the image can be found as local maxima of the destination image.
   /// </summary>
   public class CudaHarrisCorner : CudaCornernessCriteria
   {
      /// <summary>
      /// Create a Cuda Harris Corner detector
      /// </summary>
      /// <param name="blockSize">Neighborhood size </param>
      /// <param name="kSize"></param>
      /// <param name="k">Harris detector free parameter.</param>
      /// <param name="borderType">Boreder type, use REFLECT101 for default</param>
      public CudaHarrisCorner(int blockSize, int kSize, double k, CvEnum.BorderType borderType)
      {
         _ptr = CudaInvoke.cudaCreateHarrisCorner(_matType, blockSize, kSize, k, borderType);
      }
   }


   public static partial class CudaInvoke
   {
      [DllImport(CvInvoke.EXTERN_CUDA_LIBRARY, CallingConvention = CvInvoke.CvCallingConvention)]
      internal static extern IntPtr cudaCreateHarrisCorner(int srcType, int blockSize, int ksize, double k, CvEnum.BorderType borderType);
   }
}
