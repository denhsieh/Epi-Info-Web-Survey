﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace MvcDynamicForms.Fields
{
    /// <summary>
    /// Represents an html textbox input element.
    /// </summary>
    [Serializable]
    public class NumericTextBox : NumericTextField
    {
        public override string RenderHtml()
        {
            var html = new StringBuilder();
            var inputName = _form.FieldPrefix + _key;

            // prompt label
            var prompt = new TagBuilder("label");
            prompt.SetInnerText(Prompt);
            prompt.Attributes.Add("for", inputName);
            //  prompt.Attributes.Add("class", _promptClass);
            prompt.Attributes.Add("class", "EpiLabel");

            StringBuilder StyleValues = new StringBuilder();

            StyleValues.Append(GetContolStyle(_fontstyle.ToString(), _Prompttop.ToString(), _Promptleft.ToString(), _PromptWidth.ToString(), Height.ToString()));
            prompt.Attributes.Add("style", StyleValues.ToString());
            html.Append(prompt.ToString());

            // error label
            if (!IsValid)
            {
                var error = new TagBuilder("label");
                error.Attributes.Add("for", inputName);
                error.Attributes.Add("class", _errorClass);
                StringBuilder errorStyleValues = new StringBuilder();
              errorStyleValues.Append(GetContolStyle(_fontstyle.ToString(), (_Prompttop+40 ).ToString(), (_Promptleft ).ToString(), (_PromptWidth+100).ToString(), Height.ToString()));
                error.Attributes.Add("style", errorStyleValues.ToString());
                error.SetInnerText(Error);
                html.Append(error.ToString());
            }

            // input element
            var txt = new TagBuilder("input");
            txt.Attributes.Add("name", inputName);
            txt.Attributes.Add("id", inputName);
            txt.Attributes.Add("type", "text");
            txt.Attributes.Add("value", Value);

          
            if ((!string.IsNullOrEmpty(Lower)) && (!string.IsNullOrEmpty(Upper)))
            {

                txt.Attributes.Add("class", "validate[required,min[" + Lower + "],max[" + Upper + "]]"); 
            }
            else {

                txt.Attributes.Add("class", "validate[required]"); //custom[onlyLetterNumber]:No special characters allowed
            
            }
            txt.Attributes.Add("data-prompt-position", "topRight:15");


            txt.Attributes.Add("style", "position:absolute;left:" + _left.ToString() + "px;top:" + _top.ToString() + "px" + ";width:" + _ControlWidth.ToString() + "px");

            txt.MergeAttributes(_inputHtmlAttributes);
            html.Append(txt.ToString(TagRenderMode.SelfClosing));

            //adding numeric text box validation jquery script tag
            var scriptNumeric = new TagBuilder("script");
            scriptNumeric.InnerHtml = "$(function() { $('#" + inputName + "').numeric();});";
            html.Append(scriptNumeric.ToString(TagRenderMode.Normal));

            // If readonly then add the following jquery script to make the field disabled 
            if (ReadOnly)
            {
                var scriptReadOnlyText = new TagBuilder("script");
                scriptReadOnlyText.InnerHtml = "$(function(){$('#" + inputName + "').attr('disabled','disabled')});";
                html.Append(scriptReadOnlyText.ToString(TagRenderMode.Normal));
            }

            var wrapper = new TagBuilder(_fieldWrapper);
            wrapper.Attributes["class"] = _fieldWrapperClass;
            wrapper.InnerHtml = html.ToString();
            return wrapper.ToString();
        }

    }
}
