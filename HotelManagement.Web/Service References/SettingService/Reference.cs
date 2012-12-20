﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.17929
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HotelManagement.Web.SettingService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="SettingService.ISettingService")]
    public interface ISettingService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISettingService/GetAll", ReplyAction="http://tempuri.org/ISettingService/GetAllResponse")]
        HotelManagement.DTO.SettingDTO[] GetAll();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISettingService/GetSetting", ReplyAction="http://tempuri.org/ISettingService/GetSettingResponse")]
        HotelManagement.DTO.SettingDTO GetSetting(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISettingService/Save", ReplyAction="http://tempuri.org/ISettingService/SaveResponse")]
        void Save(HotelManagement.DTO.SettingDTO obj);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISettingService/Delete", ReplyAction="http://tempuri.org/ISettingService/DeleteResponse")]
        void Delete(HotelManagement.DTO.SettingDTO obj);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISettingService/GetByName", ReplyAction="http://tempuri.org/ISettingService/GetByNameResponse")]
        HotelManagement.DTO.SettingDTO GetByName(string name);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ISettingServiceChannel : HotelManagement.Web.SettingService.ISettingService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class SettingServiceClient : System.ServiceModel.ClientBase<HotelManagement.Web.SettingService.ISettingService>, HotelManagement.Web.SettingService.ISettingService {
        
        public SettingServiceClient() {
        }
        
        public SettingServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public SettingServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public SettingServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public SettingServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public HotelManagement.DTO.SettingDTO[] GetAll() {
            return base.Channel.GetAll();
        }
        
        public HotelManagement.DTO.SettingDTO GetSetting(int id) {
            return base.Channel.GetSetting(id);
        }
        
        public void Save(HotelManagement.DTO.SettingDTO obj) {
            base.Channel.Save(obj);
        }
        
        public void Delete(HotelManagement.DTO.SettingDTO obj) {
            base.Channel.Delete(obj);
        }
        
        public HotelManagement.DTO.SettingDTO GetByName(string name) {
            return base.Channel.GetByName(name);
        }
    }
}