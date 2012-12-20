﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.17929
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HotelManagement.Web.RoomService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="RoomService.IRoomService")]
    public interface IRoomService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRoomService/GetAll", ReplyAction="http://tempuri.org/IRoomService/GetAllResponse")]
        HotelManagement.DTO.RoomDTO[] GetAll();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRoomService/GetRoom", ReplyAction="http://tempuri.org/IRoomService/GetRoomResponse")]
        HotelManagement.DTO.RoomDTO GetRoom(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRoomService/Save", ReplyAction="http://tempuri.org/IRoomService/SaveResponse")]
        void Save(HotelManagement.DTO.RoomDTO obj);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRoomService/Delete", ReplyAction="http://tempuri.org/IRoomService/DeleteResponse")]
        void Delete(HotelManagement.DTO.RoomDTO obj);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IRoomServiceChannel : HotelManagement.Web.RoomService.IRoomService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class RoomServiceClient : System.ServiceModel.ClientBase<HotelManagement.Web.RoomService.IRoomService>, HotelManagement.Web.RoomService.IRoomService {
        
        public RoomServiceClient() {
        }
        
        public RoomServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public RoomServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public RoomServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public RoomServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public HotelManagement.DTO.RoomDTO[] GetAll() {
            return base.Channel.GetAll();
        }
        
        public HotelManagement.DTO.RoomDTO GetRoom(int id) {
            return base.Channel.GetRoom(id);
        }
        
        public void Save(HotelManagement.DTO.RoomDTO obj) {
            base.Channel.Save(obj);
        }
        
        public void Delete(HotelManagement.DTO.RoomDTO obj) {
            base.Channel.Delete(obj);
        }
    }
}