﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using MvcDynamicForms.Fields;
using MvcDynamicForms.Utilities;
using System.Xml.Linq;

namespace MvcDynamicForms
{
    /// <summary>
    /// Represents an html input form that can be dynamically rendered at runtime.
    /// </summary>
    [Serializable]
    [ModelBinder(typeof(DynamicFormModelBinder))]
    public class Form
    {
        private string _formWrapper = "div";
        private string _formWrapperClass = "MvcDynamicForm";
        private string _fieldPrefix = "MvcDynamicField_";
        private FieldList _fields;

        /// <summary>
        /// The html element that wraps all rendered html.
        /// </summary>
        public string FormWrapper
        {
            get
            {
                return _formWrapper;
            }
            set
            {
                _formWrapper = value;
            }
        }
        /// <summary>
        /// The class attribute of the FormWrapper element that wraps all rendered html.
        /// </summary>
        public string FormWrapperClass
        {
            get
            {
                return _formWrapperClass;
            }
            set
            {
                _formWrapperClass = value;
            }
        }
        /// <summary>
        /// A collection of Field objects.
        /// </summary>
        public FieldList Fields
        {
            get
            {
                return _fields;
            }
        }
        /// <summary>
        /// Gets or sets the string that is used to prefix html input elements' id and name attributes.
        /// </summary>
        public string FieldPrefix
        {
            get
            {
                return _fieldPrefix;
            }
            set
            {
                _fieldPrefix = value;
            }
        }
        /// <summary>
        /// Gets or sets the boolean value determining if the form should serialize itself into the string returned by the RenderHtml() method.
        /// </summary>
        public bool Serialize { get; set; }
        /// <summary>
        /// Returns an enumeration of Field objects that are of type InputField.
        /// </summary>
        public IEnumerable<InputField> InputFields
        {
            get
            {
                return _fields.OfType<InputField>();
            }
        }
        public Form()
        {
            _fields = new FieldList(this);
        }
        /// <summary>
        /// Validates each InputField object contained in the Fields collection. Validation also causes the Error property to be set for each InputField object.
        /// </summary>
        /// <returns>Returns true if every InputField object is valid. False is returned otherwise.</returns>
        public bool Validate()
        {
            bool isValid = true;

            foreach (var field in InputFields)
                if (!field.Validate())
                    isValid = false;
            return isValid;
        }
        /// <summary>
        /// Returns a string containing the rendered html of every contained Field object. The html can optionally include the Form object's state serialized into a hidden field.
        /// </summary>        
        /// <param name="formatHtml">Determines whether to format the generated html with indentation and whitespace for readability.</param>
        /// <returns>Returns a string containing the rendered html of every contained Field object.</returns>
        public string RenderHtml(bool formatHtml)
        {
            var formWrapper = new TagBuilder(_formWrapper);
            formWrapper.Attributes["class"] = _formWrapperClass;
            var html = new StringBuilder(formWrapper.ToString(TagRenderMode.StartTag));

            foreach (var field in _fields.OrderBy(x => x.DisplayOrder))
                html.Append(field.RenderHtml());

            if (Serialize)
            {
                var hdn = new TagBuilder("input");
                hdn.Attributes["type"] = "hidden";
                hdn.Attributes["id"] = MagicStrings.MvcDynamicSerializedForm;
                hdn.Attributes["name"] = MagicStrings.MvcDynamicSerializedForm;
                hdn.Attributes["value"] = SerializationUtility.Serialize(this);
                html.Append(hdn.ToString(TagRenderMode.SelfClosing));
            }

            html.Append(formWrapper.ToString(TagRenderMode.EndTag));

            if (formatHtml)
            {
                var xml = XDocument.Parse(html.ToString());
                return xml.ToString();
            }

            return html.ToString();
        }
        /// <summary>
        /// Returns a string containing the rendered html of every contained Field object. The html can optionally include the Form object's state serialized into a hidden field.
        /// </summary>
        /// <returns>Returns a string containing the rendered html of every contained Field object.</returns>
        public string RenderHtml()
        {
            return RenderHtml(false);
        }
        /// <summary>
        /// This method clears the Error property of each contained InputField.
        /// </summary>
        public void ClearAllErrors()
        {
            foreach (var inputField in InputFields)
                inputField.ClearError();
        }
        /// <summary>
        /// This method provides a convenient way of adding multiple Field objects at once.
        /// </summary>
        /// <param name="fields">Field object(s)</param>
        public void AddFields(params Field[] fields)
        {
            foreach (var field in fields)
            {
                _fields.Add(field);
            }
        }
        /// <summary>
        /// Provides a convenient way the end users' responses to each InputField
        /// </summary>
        /// <param name="completedOnly">Determines whether to return a Response object for only InputFields that the end user completed.</param>
        /// <returns>List of Response objects.</returns>
        public List<Response> GetResponses(bool completedOnly)
        {
            var responses = new List<Response>();
            foreach (var field in InputFields.OrderBy(x => x.DisplayOrder))
            {
                var response = new Response
                {
                    Title = field.Title,
                    Value = field.Response
                };

                if (completedOnly && string.IsNullOrEmpty(response.Value))
                    continue;

                responses.Add(response);
            }

            return responses;
        }
    }
}
