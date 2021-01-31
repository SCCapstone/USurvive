﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by coded UI test builder.
//      Version: 16.0.0.0
//
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------

namespace UITests
{
    using System;
    using System.CodeDom.Compiler;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Text.RegularExpressions;
    using System.Windows.Input;
    using Microsoft.VisualStudio.TestTools.UITest.Extension;
    using Microsoft.VisualStudio.TestTools.UITesting;
    using Microsoft.VisualStudio.TestTools.UITesting.WpfControls;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Keyboard = Microsoft.VisualStudio.TestTools.UITesting.Keyboard;
    using Mouse = Microsoft.VisualStudio.TestTools.UITesting.Mouse;
    using MouseButtons = System.Windows.Forms.MouseButtons;
    
    
    [GeneratedCode("Coded UITest Builder", "16.0.29514.35")]
    public partial class UIMap
    {
        
        /// <summary>
        /// AddClass - Use 'AddClassParams' to pass parameters into this method.
        /// </summary>
        public void AddClass()
        {
            #region Variable Declarations
            WpfButton uIAddClassButton = this.UIUSurviveWindow.UINavigationFramePane.UIAddClassButton;
            WpfWindow uIEditClassWindow = this.UIEditClassWindow;
            WpfEdit uITbNameEdit = this.UIEditClassWindow.UITbNameEdit;
            WpfEdit uITbInstructorEdit = this.UIEditClassWindow.UITbInstructorEdit;
            WpfEdit uITbCreditHoursEdit = this.UIEditClassWindow.UITbCreditHoursEdit;
            WpfEdit uITbInstEmailEdit = this.UIEditClassWindow.UITbInstEmailEdit;
            WpfEdit uITbWebsiteEdit = this.UIEditClassWindow.UITbWebsiteEdit;
            WpfEdit uITbNotesEdit = this.UIEditClassWindow.UITbNotesEdit;
            WpfButton uISaveButton = this.UIEditClassWindow.UISaveButton;
            #endregion

            // Click 'Add Class' button
            Mouse.Click(uIAddClassButton, new Point(90, 13));

            // Click 'EditClass' window
            Mouse.Click(uIEditClassWindow, new Point(354, 40));

            // Type 'Name' in 'tbName' text box
            uITbNameEdit.Text = this.AddClassParams.UITbNameEditText;

            // Type '{Tab}' in 'tbName' text box
            Keyboard.SendKeys(uITbNameEdit, this.AddClassParams.UITbNameEditSendKeys, ModifierKeys.None);

            // Type 'Inst' in 'tbInstructor' text box
            uITbInstructorEdit.Text = this.AddClassParams.UITbInstructorEditText;

            // Type '{Tab}' in 'tbInstructor' text box
            Keyboard.SendKeys(uITbInstructorEdit, this.AddClassParams.UITbInstructorEditSendKeys, ModifierKeys.None);

            // Type '5' in 'tbCreditHours' text box
            uITbCreditHoursEdit.Text = this.AddClassParams.UITbCreditHoursEditText;

            // Type '{Tab}' in 'tbCreditHours' text box
            Keyboard.SendKeys(uITbCreditHoursEdit, this.AddClassParams.UITbCreditHoursEditSendKeys, ModifierKeys.None);

            // Type 'inst@college.edu' in 'tbInstEmail' text box
            uITbInstEmailEdit.Text = this.AddClassParams.UITbInstEmailEditText;

            // Type '{Tab}' in 'tbInstEmail' text box
            Keyboard.SendKeys(uITbInstEmailEdit, this.AddClassParams.UITbInstEmailEditSendKeys, ModifierKeys.None);

            // Type 'college.edu/inst.html' in 'tbWebsite' text box
            uITbWebsiteEdit.Text = this.AddClassParams.UITbWebsiteEditText;

            // Type '{Tab}' in 'tbWebsite' text box
            Keyboard.SendKeys(uITbWebsiteEdit, this.AddClassParams.UITbWebsiteEditSendKeys, ModifierKeys.None);

            // Type 'NOtess' in 'tbNotes' text box
            uITbNotesEdit.Text = this.AddClassParams.UITbNotesEditText;

            // Click 'Save' button
            Mouse.Click(uISaveButton, new Point(42, 11));
        }
        
        /// <summary>
        /// AddClassVerify - Use 'AddClassVerifyExpectedValues' to pass parameters into this method.
        /// </summary>
        public void AddClassVerify()
        {
            #region Variable Declarations
            WpfRow uINameInst5Row = this.UIUSurviveWindow.UINavigationFramePane.UIDgClassListTable.UINameInst5Row;
            #endregion

            // Verify that the 'ControlType' property of 'Name,Inst,5,' row equals 'Row'
            Assert.AreEqual(this.AddClassVerifyExpectedValues.UINameInst5RowControlType, uINameInst5Row.ControlType.ToString(), "Not added to DataGrid!");
        }
        
        #region Properties
        public virtual AddClassParams AddClassParams
        {
            get
            {
                if ((this.mAddClassParams == null))
                {
                    this.mAddClassParams = new AddClassParams();
                }
                return this.mAddClassParams;
            }
        }
        
        public virtual AddClassVerifyExpectedValues AddClassVerifyExpectedValues
        {
            get
            {
                if ((this.mAddClassVerifyExpectedValues == null))
                {
                    this.mAddClassVerifyExpectedValues = new AddClassVerifyExpectedValues();
                }
                return this.mAddClassVerifyExpectedValues;
            }
        }
        
        public UIUSurviveWindow UIUSurviveWindow
        {
            get
            {
                if ((this.mUIUSurviveWindow == null))
                {
                    this.mUIUSurviveWindow = new UIUSurviveWindow();
                }
                return this.mUIUSurviveWindow;
            }
        }
        
        public UIEditClassWindow UIEditClassWindow
        {
            get
            {
                if ((this.mUIEditClassWindow == null))
                {
                    this.mUIEditClassWindow = new UIEditClassWindow();
                }
                return this.mUIEditClassWindow;
            }
        }
        #endregion
        
        #region Fields
        private AddClassParams mAddClassParams;
        
        private AddClassVerifyExpectedValues mAddClassVerifyExpectedValues;
        
        private UIUSurviveWindow mUIUSurviveWindow;
        
        private UIEditClassWindow mUIEditClassWindow;
        #endregion
    }
    
    /// <summary>
    /// Parameters to be passed into 'AddClass'
    /// </summary>
    [GeneratedCode("Coded UITest Builder", "16.0.29514.35")]
    public class AddClassParams
    {
        
        #region Fields
        /// <summary>
        /// Type 'Name' in 'tbName' text box
        /// </summary>
        public string UITbNameEditText = "Name";
        
        /// <summary>
        /// Type '{Tab}' in 'tbName' text box
        /// </summary>
        public string UITbNameEditSendKeys = "{Tab}";
        
        /// <summary>
        /// Type 'Inst' in 'tbInstructor' text box
        /// </summary>
        public string UITbInstructorEditText = "Inst";
        
        /// <summary>
        /// Type '{Tab}' in 'tbInstructor' text box
        /// </summary>
        public string UITbInstructorEditSendKeys = "{Tab}";
        
        /// <summary>
        /// Type '5' in 'tbCreditHours' text box
        /// </summary>
        public string UITbCreditHoursEditText = "5";
        
        /// <summary>
        /// Type '{Tab}' in 'tbCreditHours' text box
        /// </summary>
        public string UITbCreditHoursEditSendKeys = "{Tab}";
        
        /// <summary>
        /// Type 'inst@college.edu' in 'tbInstEmail' text box
        /// </summary>
        public string UITbInstEmailEditText = "inst@college.edu";
        
        /// <summary>
        /// Type '{Tab}' in 'tbInstEmail' text box
        /// </summary>
        public string UITbInstEmailEditSendKeys = "{Tab}";
        
        /// <summary>
        /// Type 'college.edu/inst.html' in 'tbWebsite' text box
        /// </summary>
        public string UITbWebsiteEditText = "college.edu/inst.html";
        
        /// <summary>
        /// Type '{Tab}' in 'tbWebsite' text box
        /// </summary>
        public string UITbWebsiteEditSendKeys = "{Tab}";
        
        /// <summary>
        /// Type 'NOtess' in 'tbNotes' text box
        /// </summary>
        public string UITbNotesEditText = "NOtess";
        #endregion
    }
    
    /// <summary>
    /// Parameters to be passed into 'AddClassVerify'
    /// </summary>
    [GeneratedCode("Coded UITest Builder", "16.0.29514.35")]
    public class AddClassVerifyExpectedValues
    {
        
        #region Fields
        /// <summary>
        /// Verify that the 'ControlType' property of 'Name,Inst,5,' row equals 'Row'
        /// </summary>
        public string UINameInst5RowControlType = "Row";
        #endregion
    }
    
    [GeneratedCode("Coded UITest Builder", "16.0.29514.35")]
    public class UIUSurviveWindow : WpfWindow
    {
        
        public UIUSurviveWindow()
        {
            #region Search Criteria
            this.SearchProperties[WpfWindow.PropertyNames.Name] = "USurvive";
            this.SearchProperties.Add(new PropertyExpression(WpfWindow.PropertyNames.ClassName, "HwndWrapper", PropertyExpressionOperator.Contains));
            this.WindowTitles.Add("USurvive");
            #endregion
        }
        
        #region Properties
        public UINavigationFramePane UINavigationFramePane
        {
            get
            {
                if ((this.mUINavigationFramePane == null))
                {
                    this.mUINavigationFramePane = new UINavigationFramePane(this);
                }
                return this.mUINavigationFramePane;
            }
        }
        #endregion
        
        #region Fields
        private UINavigationFramePane mUINavigationFramePane;
        #endregion
    }
    
    [GeneratedCode("Coded UITest Builder", "16.0.29514.35")]
    public class UINavigationFramePane : WpfPane
    {
        
        public UINavigationFramePane(UITestControl searchLimitContainer) : 
                base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[WpfPane.PropertyNames.ClassName] = "Uia.Frame";
            this.SearchProperties[WpfPane.PropertyNames.AutomationId] = "NavigationFrame";
            this.WindowTitles.Add("USurvive");
            #endregion
        }
        
        #region Properties
        public WpfButton UIAddClassButton
        {
            get
            {
                if ((this.mUIAddClassButton == null))
                {
                    this.mUIAddClassButton = new WpfButton(this);
                    #region Search Criteria
                    this.mUIAddClassButton.SearchProperties[WpfButton.PropertyNames.Name] = "Add Class";
                    this.mUIAddClassButton.WindowTitles.Add("USurvive");
                    #endregion
                }
                return this.mUIAddClassButton;
            }
        }
        
        public UIDgClassListTable UIDgClassListTable
        {
            get
            {
                if ((this.mUIDgClassListTable == null))
                {
                    this.mUIDgClassListTable = new UIDgClassListTable(this);
                }
                return this.mUIDgClassListTable;
            }
        }
        #endregion
        
        #region Fields
        private WpfButton mUIAddClassButton;
        
        private UIDgClassListTable mUIDgClassListTable;
        #endregion
    }
    
    [GeneratedCode("Coded UITest Builder", "16.0.29514.35")]
    public class UIDgClassListTable : WpfTable
    {
        
        public UIDgClassListTable(UITestControl searchLimitContainer) : 
                base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[WpfTable.PropertyNames.AutomationId] = "dgClassList";
            this.WindowTitles.Add("USurvive");
            #endregion
        }
        
        #region Properties
        public UINameInst5Row UINameInst5Row
        {
            get
            {
                if ((this.mUINameInst5Row == null))
                {
                    this.mUINameInst5Row = new UINameInst5Row(this);
                }
                return this.mUINameInst5Row;
            }
        }
        #endregion
        
        #region Fields
        private UINameInst5Row mUINameInst5Row;
        #endregion
    }
    
    [GeneratedCode("Coded UITest Builder", "16.0.29514.35")]
    public class UINameInst5Row : WpfRow
    {
        
        public UINameInst5Row(UITestControl searchLimitContainer) : 
                base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[WpfRow.PropertyNames.Name] = "Name,Inst,5,";
            this.SearchConfigurations.Add(SearchConfiguration.AlwaysSearch);
            this.WindowTitles.Add("USurvive");
            #endregion
        }
        
        #region Properties
        public UINameCell UINameCell
        {
            get
            {
                if ((this.mUINameCell == null))
                {
                    this.mUINameCell = new UINameCell(this);
                }
                return this.mUINameCell;
            }
        }
        #endregion
        
        #region Fields
        private UINameCell mUINameCell;
        #endregion
    }
    
    [GeneratedCode("Coded UITest Builder", "16.0.29514.35")]
    public class UINameCell : WpfCell
    {
        
        public UINameCell(UITestControl searchLimitContainer) : 
                base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[WpfCell.PropertyNames.ColumnHeader] = "Name";
            this.WindowTitles.Add("USurvive");
            #endregion
        }
        
        #region Properties
        public WpfText UINameText
        {
            get
            {
                if ((this.mUINameText == null))
                {
                    this.mUINameText = new WpfText(this);
                    #region Search Criteria
                    this.mUINameText.SearchProperties[WpfText.PropertyNames.Name] = "Name";
                    this.mUINameText.WindowTitles.Add("USurvive");
                    #endregion
                }
                return this.mUINameText;
            }
        }
        #endregion
        
        #region Fields
        private WpfText mUINameText;
        #endregion
    }
    
    [GeneratedCode("Coded UITest Builder", "16.0.29514.35")]
    public class UIEditClassWindow : WpfWindow
    {
        
        public UIEditClassWindow()
        {
            #region Search Criteria
            this.SearchProperties[WpfWindow.PropertyNames.Name] = "EditClass";
            this.SearchProperties.Add(new PropertyExpression(WpfWindow.PropertyNames.ClassName, "HwndWrapper", PropertyExpressionOperator.Contains));
            this.WindowTitles.Add("EditClass");
            #endregion
        }
        
        #region Properties
        public WpfEdit UITbNameEdit
        {
            get
            {
                if ((this.mUITbNameEdit == null))
                {
                    this.mUITbNameEdit = new WpfEdit(this);
                    #region Search Criteria
                    this.mUITbNameEdit.SearchProperties[WpfEdit.PropertyNames.AutomationId] = "tbName";
                    this.mUITbNameEdit.WindowTitles.Add("EditClass");
                    #endregion
                }
                return this.mUITbNameEdit;
            }
        }
        
        public WpfEdit UITbInstructorEdit
        {
            get
            {
                if ((this.mUITbInstructorEdit == null))
                {
                    this.mUITbInstructorEdit = new WpfEdit(this);
                    #region Search Criteria
                    this.mUITbInstructorEdit.SearchProperties[WpfEdit.PropertyNames.AutomationId] = "tbInstructor";
                    this.mUITbInstructorEdit.WindowTitles.Add("EditClass");
                    #endregion
                }
                return this.mUITbInstructorEdit;
            }
        }
        
        public WpfEdit UITbCreditHoursEdit
        {
            get
            {
                if ((this.mUITbCreditHoursEdit == null))
                {
                    this.mUITbCreditHoursEdit = new WpfEdit(this);
                    #region Search Criteria
                    this.mUITbCreditHoursEdit.SearchProperties[WpfEdit.PropertyNames.AutomationId] = "tbCreditHours";
                    this.mUITbCreditHoursEdit.WindowTitles.Add("EditClass");
                    #endregion
                }
                return this.mUITbCreditHoursEdit;
            }
        }
        
        public WpfEdit UITbInstEmailEdit
        {
            get
            {
                if ((this.mUITbInstEmailEdit == null))
                {
                    this.mUITbInstEmailEdit = new WpfEdit(this);
                    #region Search Criteria
                    this.mUITbInstEmailEdit.SearchProperties[WpfEdit.PropertyNames.AutomationId] = "tbInstEmail";
                    this.mUITbInstEmailEdit.WindowTitles.Add("EditClass");
                    #endregion
                }
                return this.mUITbInstEmailEdit;
            }
        }
        
        public WpfEdit UITbWebsiteEdit
        {
            get
            {
                if ((this.mUITbWebsiteEdit == null))
                {
                    this.mUITbWebsiteEdit = new WpfEdit(this);
                    #region Search Criteria
                    this.mUITbWebsiteEdit.SearchProperties[WpfEdit.PropertyNames.AutomationId] = "tbWebsite";
                    this.mUITbWebsiteEdit.WindowTitles.Add("EditClass");
                    #endregion
                }
                return this.mUITbWebsiteEdit;
            }
        }
        
        public WpfEdit UITbNotesEdit
        {
            get
            {
                if ((this.mUITbNotesEdit == null))
                {
                    this.mUITbNotesEdit = new WpfEdit(this);
                    #region Search Criteria
                    this.mUITbNotesEdit.SearchProperties[WpfEdit.PropertyNames.AutomationId] = "tbNotes";
                    this.mUITbNotesEdit.WindowTitles.Add("EditClass");
                    #endregion
                }
                return this.mUITbNotesEdit;
            }
        }
        
        public WpfButton UISaveButton
        {
            get
            {
                if ((this.mUISaveButton == null))
                {
                    this.mUISaveButton = new WpfButton(this);
                    #region Search Criteria
                    this.mUISaveButton.SearchProperties[WpfButton.PropertyNames.Name] = "Save";
                    this.mUISaveButton.WindowTitles.Add("EditClass");
                    #endregion
                }
                return this.mUISaveButton;
            }
        }
        #endregion
        
        #region Fields
        private WpfEdit mUITbNameEdit;
        
        private WpfEdit mUITbInstructorEdit;
        
        private WpfEdit mUITbCreditHoursEdit;
        
        private WpfEdit mUITbInstEmailEdit;
        
        private WpfEdit mUITbWebsiteEdit;
        
        private WpfEdit mUITbNotesEdit;
        
        private WpfButton mUISaveButton;
        #endregion
    }
}
