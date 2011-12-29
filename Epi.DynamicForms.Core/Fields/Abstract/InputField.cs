﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace MvcDynamicForms.Fields
{
    /// <summary>
    /// Represents a dynamically generated html input field.
    /// </summary>
    [Serializable]
    public abstract class InputField : Field
    {
        protected double _Prompttop;
        protected double _Promptleft;
        protected double _PromptWidth;
        protected double _ControlWidth;
        protected double _ControlHeight;
        protected string _key = Guid.NewGuid().ToString();
        protected string _requiredMessage = "Required";
        protected string _promptClass = "MvcDynamicFieldPrompt";
        protected string _errorClass = "MvcDynamicFieldError";
        protected Boolean _IsRequired;
        protected Boolean _IsReadOnly;
       

        protected Dictionary<string, string> _inputHtmlAttributes = new Dictionary<string, string>();
        /// <summary>
        /// Used to identify each InputField when performing model binding.
        /// </summary>
        public string Key
        {
            get
            {
                return _key;
            }
            set
            {
                _key = value;
            }
        }
        /// <summary>
        /// Used to identify InputFields when working with end users' responses.
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// The question asked of the end user. This text appears before the html input element.
        /// </summary>
        public string Prompt { get; set; }
        /// <summary>
        /// The html class applied to the label element that appears before the input element.
        /// </summary>
        public string PromptClass
        {
            get
            {
                return _promptClass;
            }
            set
            {
                _promptClass = value;
            }
        }
        /// <summary>
        /// String representing the user's response to the field.
        /// </summary>
        public abstract string Response { get; }
        /// <summary>
        /// Whether the field must be completed to be valid.
        /// </summary>
        public bool Required { get; set; }

        /// <summary>
        /// Whether the field is readonly. If the field is readonly then the required = false
        /// </summary>
        public bool ReadOnly { get; set; }
        /// <summary>
        /// The error message that the end user sees if they do not complete the field.
        /// </summary>
        public string RequiredMessage
        {
            get
            {
                return _requiredMessage;
            }
            set
            {
                _requiredMessage = value;
            }
        }
        /// <summary>
        /// The error message that the end user sees.
        /// </summary>
        public string Error { get; set; }
        /// <summary>
        /// The class attribute of the label element that is used to display an error message to the user.
        /// </summary>
        public string ErrorClass
        {
            get
            {
                return _errorClass;
            }
            set
            {
                _errorClass = value;
            }
        }
        /// <summary>
        /// True if the field is valid; false otherwise.
        /// </summary>
        public bool IsValid
        {
            get
            {
                return string.IsNullOrEmpty(Error);
            }
        }
        /// <summary>
        /// Collection of html attribute names and values that will be applied to the rendered input elements.
        /// </summary>
        public Dictionary<string, string> InputHtmlAttributes
        {
            get
            {
                return _inputHtmlAttributes;
            }
            set
            {
                _inputHtmlAttributes = value;
            }
        }
        /// <summary>
        /// Validates the user's response.
        /// </summary>
        /// <returns></returns>
        public abstract bool Validate();        
        /// <summary>
        /// Removes the message stored in the Error property.
        /// </summary>
        public void ClearError()
        {
            Error = null;
        }
         
        public double PromptTop { get { return this._Prompttop; } set { this._Prompttop = value; } }
        public double PromptLeft { get { return this._Promptleft; } set { this._Promptleft = value; } }

        public double PromptWidth { get { return this._PromptWidth; } set { this._PromptWidth = value; } }
        public double ControlWidth { get { return this._ControlWidth; } set { this._ControlWidth = value; } }
       
        public double ControlHeight { get { return this._ControlHeight; } set { this._ControlHeight = value; } }
        public Boolean IsRequired { get { return this._IsRequired; } set {   this._IsRequired =value; } }
        public Boolean IsReadOnly { get { return this._IsReadOnly; } set {   this._IsReadOnly = value; }}
      
    }
}
