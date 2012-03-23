﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.261
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Epi.Web.DataServiceClient {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="DataServiceClient.IDataService")]
    public interface IDataService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDataService/GetSurveyInfo", ReplyAction="http://tempuri.org/IDataService/GetSurveyInfoResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(Epi.Web.Common.Exception.CustomFaultException), Action="http://tempuri.org/IDataService/GetSurveyInfoCustomFaultExceptionFault", Name="CustomFaultException", Namespace="http://www.yourcompany.com/types/")]
        Epi.Web.Common.Message.SurveyInfoResponse GetSurveyInfo(Epi.Web.Common.Message.SurveyInfoRequest pRequest);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDataService/GetSurveyAnswer", ReplyAction="http://tempuri.org/IDataService/GetSurveyAnswerResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(Epi.Web.Common.Exception.CustomFaultException), Action="http://tempuri.org/IDataService/GetSurveyAnswerCustomFaultExceptionFault", Name="CustomFaultException", Namespace="http://www.yourcompany.com/types/")]
        Epi.Web.Common.Message.SurveyAnswerResponse GetSurveyAnswer(Epi.Web.Common.Message.SurveyAnswerRequest pRequest);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDataService/SetSurveyAnswer", ReplyAction="http://tempuri.org/IDataService/SetSurveyAnswerResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(Epi.Web.Common.Exception.CustomFaultException), Action="http://tempuri.org/IDataService/SetSurveyAnswerCustomFaultExceptionFault", Name="CustomFaultException", Namespace="http://www.yourcompany.com/types/")]
        Epi.Web.Common.Message.SurveyAnswerResponse SetSurveyAnswer(Epi.Web.Common.Message.SurveyAnswerRequest pRequest);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IDataServiceChannel : Epi.Web.DataServiceClient.IDataService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class DataServiceClient : System.ServiceModel.ClientBase<Epi.Web.DataServiceClient.IDataService>, Epi.Web.DataServiceClient.IDataService {
        
        public DataServiceClient() {
        }
        
        public DataServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public DataServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public DataServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public DataServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public Epi.Web.Common.Message.SurveyInfoResponse GetSurveyInfo(Epi.Web.Common.Message.SurveyInfoRequest pRequest) {
            return base.Channel.GetSurveyInfo(pRequest);
        }
        
        public Epi.Web.Common.Message.SurveyAnswerResponse GetSurveyAnswer(Epi.Web.Common.Message.SurveyAnswerRequest pRequest) {
            return base.Channel.GetSurveyAnswer(pRequest);
        }
        
        public Epi.Web.Common.Message.SurveyAnswerResponse SetSurveyAnswer(Epi.Web.Common.Message.SurveyAnswerRequest pRequest) {
            return base.Channel.SetSurveyAnswer(pRequest);
        }
    }
}
