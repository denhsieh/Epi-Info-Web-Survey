﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.239
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Epi.Web.SurveyManager_Test.SurveyManagerService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="SurveyManagerService.IManagerService")]
    public interface IManagerService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IManagerService/PublishSurvey", ReplyAction="http://tempuri.org/IManagerService/PublishSurveyResponse")]
        Epi.Web.Common.Message.PublishResponse PublishSurvey(Epi.Web.Common.Message.PublishRequest pRequestMessage);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IManagerServiceChannel : Epi.Web.SurveyManager_Test.SurveyManagerService.IManagerService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ManagerServiceClient : System.ServiceModel.ClientBase<Epi.Web.SurveyManager_Test.SurveyManagerService.IManagerService>, Epi.Web.SurveyManager_Test.SurveyManagerService.IManagerService {
        
        public ManagerServiceClient() {
        }
        
        public ManagerServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ManagerServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ManagerServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ManagerServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public Epi.Web.Common.Message.PublishResponse PublishSurvey(Epi.Web.Common.Message.PublishRequest pRequestMessage) {
            return base.Channel.PublishSurvey(pRequestMessage);
        }
    }
}
