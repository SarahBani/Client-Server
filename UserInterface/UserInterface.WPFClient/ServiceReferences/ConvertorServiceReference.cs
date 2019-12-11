using Core.DomainModel;
using Core.DomainService;
using Core.DomainService.Services;
using System;
using System.Net.Sockets;
using System.ServiceModel;
using System.Threading.Tasks;

namespace UserInterface.WPFClient.ServiceReferences
{
    public class ConvertorServiceReference
    {

        #region Properties

        private readonly string _wcfServiceUri;

        #endregion /Properties

        #region Constructors

        public ConvertorServiceReference()
        {
            this._wcfServiceUri = Utility.GetAppSetting(Constant.AppSetting_ConvertorServiceUrl);
        }

        #endregion /Constructors

        #region Methods

        public async Task<string> GetConvertedWordAsync(string inputNumber)
        {
            // Create a channel factory.
            var binding = new BasicHttpBinding();
            var endpoint = new EndpointAddress(this._wcfServiceUri);
            var channelFactory = new ChannelFactory<IConvertorService>(binding, endpoint);
            // Create a channel
            IConvertorService wcfClient = channelFactory.CreateChannel();
            try
            {
                return await wcfClient.ConvertNumberToWordAsync(inputNumber);
            }
            catch (EndpointNotFoundException)
            {
                throw new Exception(Constant.Exception_ConnectionFailed);
            }
            catch (CommunicationException ex)
            {
                if (ex.GetBaseException() is SocketException)
                {
                    throw new Exception(Constant.Exception_ConnectionFailed);
                }
                throw;
            }
            catch (Exception ex)
            {
                throw new Exception(Constant.Exception_HasError);
            }
            finally
            {
                ((IClientChannel)wcfClient).Close();
                channelFactory.Close();
            }
        }
        
        #endregion /Methods

    }
}
