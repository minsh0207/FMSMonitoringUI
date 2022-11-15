/////////////////////////////////////////////////////////////////////////////
//***************************************************************************
//  Description		: CBoxClickedEventArgs
//  Create Data		: 
//  Author			: 
//  Remark			:
//***************************************************************************
/////////////////////////////////////////////////////////////////////////////


/////////////////////////////////////////////////////////////////////
//	Using
//===================================================================
using System;
using System.Windows;


/////////////////////////////////////////////////////////////////////
//	Namespace:  FormationMonCtrl
//===================================================================
namespace FormationMonCtrl
{
    #region [Class CBoxClickedEventArgs]
    /////////////////////////////////////////////////////////////////////
    //	Class:  CBoxClickedEventArgs
    //===================================================================
    public class CBoxClickedEventArgs : RoutedEventArgs
    {
        #region [Variable]
        private int m_nBoxNumber;
        #endregion

        #region [Constructor]
        /////////////////////////////////////////////////////////////////////
        //	Constructor
        //===================================================================
        internal CBoxClickedEventArgs(int nBoxNumber)
        {
            this.m_nBoxNumber = nBoxNumber;
        }
        #endregion

        #region [Method]
        #region [BoxNumber]
        /////////////////////////////////////////////////////////////////////
        //	BoxNumber
        //===================================================================
        public int BoxNumber
        {
            get { return m_nBoxNumber; }
        }
        #endregion
        #endregion
    }
    #endregion
}
