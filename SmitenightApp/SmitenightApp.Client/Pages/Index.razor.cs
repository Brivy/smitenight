using Blazorise;
using Microsoft.AspNetCore.Components;
using SmitenightApp.Client.Constants;
using SmitenightApp.Client.Extensions;
using SmitenightApp.Client.Forms.Smitenights;
using SmitenightApp.Client.Interfaces;
using SmitenightApp.Domain.Contracts.Smitenights;

namespace SmitenightApp.Client.Pages
{
    public partial class Index
    {
        private string FormStyle { get; set; } = null!;
        private string ButtonStyle { get; set; } = null!;
        private string PinStyle { get; set; } = null!;
        private string LoaderStyle { get; set; } = null!;

        private Validations SmitenightValidations { get; set; } = null!;
        private Alert SmitenightSuccessAlert { get; set; } = null!;
        private string SmitenightSuccessAlertMessage { get; set; } = string.Empty;
        private Alert SmitenightErrorAlert { get; set; } = null!;
        private string SmitenightErrorAlertMessage { get; set; } = string.Empty;

        private readonly SmitenightProcessModel _smitenightProcessModel = new();

        [Inject] private ISmitenightClient SmitenightClient { get; set; } = null!;

        private async Task StartSmitenightAsync(CancellationToken cancellationToken = default)
        {
            var validate = await SmitenightValidations.ValidateAll();
            if (!validate)
            {
                return;
            }

            await SetBoxStylingAsync();
            var requestDto = CreateSmitenightProcessRequest();
            var responseDto = await SmitenightClient.StartSmitenightAsync(requestDto, cancellationToken);
            if (responseDto.IsSuccessStatusCode)
            {
                SmitenightSuccessAlertMessage = UserMessages.SmitenightStarted;
                await SmitenightSuccessAlert.Show();
            }
            else
            {
                SmitenightErrorAlertMessage = responseDto.StatusCode.MapUserMessageByStatusCode();
                await SmitenightErrorAlert.Show();
            }

            UndoBoxStyling();
        }

        private async Task EndSmitenightAsync(CancellationToken cancellationToken = default)
        {
            var validate = await SmitenightValidations.ValidateAll();
            if (!validate)
            {
                return;
            }

            await SetBoxStylingAsync();
            var requestDto = CreateSmitenightProcessRequest();
            var responseDto = await SmitenightClient.EndSmitenightAsync(requestDto, cancellationToken);
            if (responseDto.IsSuccessStatusCode)
            {
                SmitenightSuccessAlertMessage = UserMessages.SmitenightEnded;
                await SmitenightSuccessAlert.Show();
            }
            else
            {
                SmitenightErrorAlertMessage = responseDto.StatusCode.MapUserMessageByStatusCode();
                await SmitenightErrorAlert.Show();
            }

            UndoBoxStyling();
        }

        private void OnPinCodeCheckChange(bool value)
        {
            _smitenightProcessModel.PinCodeCheck = value;
            PinStyle = value
                ? StylingConstants.DisplayBlock
                : StylingConstants.DisplayNone;
        }

        #region Helper methods

        private SmitenightProcessDto CreateSmitenightProcessRequest()
        {
            return new SmitenightProcessDto
            {
                PlayerName = _smitenightProcessModel.PlayerName,
                PinCode = _smitenightProcessModel.PinCodeCheck
                    ? !string.IsNullOrWhiteSpace(_smitenightProcessModel.PinCode)
                        ? _smitenightProcessModel.PinCode
                        : null
                    : null
            };
        }

        private async Task SetBoxStylingAsync()
        {
            await SmitenightSuccessAlert.Hide();
            await SmitenightErrorAlert.Hide();
            FormStyle = StylingConstants.OpacityToAQuarter;
            ButtonStyle = StylingConstants.DisplayNone;
            LoaderStyle = StylingConstants.DisplayBlock;
        }

        private void UndoBoxStyling()
        {
            FormStyle = string.Empty;
            ButtonStyle = string.Empty;
            LoaderStyle = StylingConstants.DisplayNone;
        }

        #endregion
    }
}
