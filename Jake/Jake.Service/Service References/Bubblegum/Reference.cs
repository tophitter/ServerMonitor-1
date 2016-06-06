﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Jake.Service.Bubblegum {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://bubblegum.laberko.net", ConfigurationName="Bubblegum.IServer")]
    public interface IServer {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://bubblegum.laberko.net/IServer/GetConfigChanged", ReplyAction="http://bubblegum.laberko.net/IServer/GetConfigChangedResponse")]
        bool GetConfigChanged(System.Guid serverId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://bubblegum.laberko.net/IServer/GetConfigChanged", ReplyAction="http://bubblegum.laberko.net/IServer/GetConfigChangedResponse")]
        System.Threading.Tasks.Task<bool> GetConfigChangedAsync(System.Guid serverId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://bubblegum.laberko.net/IServer/GetConfig", ReplyAction="http://bubblegum.laberko.net/IServer/GetConfigResponse")]
        Common.SrvMonParams GetConfig(Common.SrvMonParams jakeParams, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://bubblegum.laberko.net/IServer/GetConfig", ReplyAction="http://bubblegum.laberko.net/IServer/GetConfigResponse")]
        System.Threading.Tasks.Task<Common.SrvMonParams> GetConfigAsync(Common.SrvMonParams jakeParams, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://bubblegum.laberko.net/IServer/SendData", ReplyAction="http://bubblegum.laberko.net/IServer/SendDataResponse")]
        void SendData(Common.SrvMonSummary summary, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://bubblegum.laberko.net/IServer/SendData", ReplyAction="http://bubblegum.laberko.net/IServer/SendDataResponse")]
        System.Threading.Tasks.Task SendDataAsync(Common.SrvMonSummary summary, string password);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IServerChannel : Jake.Service.Bubblegum.IServer, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ServerClient : System.ServiceModel.ClientBase<Jake.Service.Bubblegum.IServer>, Jake.Service.Bubblegum.IServer {
        
        public ServerClient() {
        }
        
        public ServerClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ServerClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServerClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServerClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public bool GetConfigChanged(System.Guid serverId) {
            return base.Channel.GetConfigChanged(serverId);
        }
        
        public System.Threading.Tasks.Task<bool> GetConfigChangedAsync(System.Guid serverId) {
            return base.Channel.GetConfigChangedAsync(serverId);
        }
        
        public Common.SrvMonParams GetConfig(Common.SrvMonParams jakeParams, string password) {
            return base.Channel.GetConfig(jakeParams, password);
        }
        
        public System.Threading.Tasks.Task<Common.SrvMonParams> GetConfigAsync(Common.SrvMonParams jakeParams, string password) {
            return base.Channel.GetConfigAsync(jakeParams, password);
        }
        
        public void SendData(Common.SrvMonSummary summary, string password) {
            base.Channel.SendData(summary, password);
        }
        
        public System.Threading.Tasks.Task SendDataAsync(Common.SrvMonSummary summary, string password) {
            return base.Channel.SendDataAsync(summary, password);
        }
    }
}
