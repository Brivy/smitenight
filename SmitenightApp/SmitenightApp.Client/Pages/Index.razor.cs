using System.Net.Http.Json;
using Blazorise;
using Microsoft.AspNetCore.Components;
using SmitenightApp.Client.Forms.Smitenights;
using SmitenightApp.Domain.Constants.Endpoints;
using SmitenightApp.Domain.Contracts.Smitenights;

namespace SmitenightApp.Client.Pages
{
    public partial class Index
    {
        private string FormStyle { get; set; } = null!;
        private string ButtonStyle { get; set; } = null!;
        private string LoaderStyle { get; set; } = null!;

        private Validations SmitenightValidations { get; set; } = null!;
        private Alert SmitenightSuccessAlert { get; set; } = null!;
        private string SmitenightSuccessAlertMessage { get; set; } = string.Empty;
        private Alert SmitenightErrorAlert { get; set; } = null!;
        private string SmitenightErrorAlertMessage { get; set; } = string.Empty;

        private readonly SmitenightProcessModel _smitenightProcessModel = new();

        [Inject] private HttpClient HttpClient { get; set; } = null!;

        private async Task StartSmitenightAsync()
        {
            var validate = await SmitenightValidations.ValidateAll();
            if (!validate)
            {
                return;
            }

            SetBoxStyling();
            var requestDto = CreateSmitenightProcessRequest();
            var response = await HttpClient.PostAsJsonAsync(SmitenightEndpoints.StartSmitenight, requestDto, CancellationToken.None);
            if (!response.IsSuccessStatusCode)
            {
                SmitenightErrorAlertMessage = "Something went wrong";
                await SmitenightErrorAlert.Show();
            }
            else
            {
                SmitenightSuccessAlertMessage = "Smitenight started!";
                await SmitenightSuccessAlert.Show();
            }

            UndoBoxStyling();
        }

        private async Task EndSmitenightAsync()
        {
            var validate = await SmitenightValidations.ValidateAll();
            if (!validate)
            {
                UndoBoxStyling();
                return;
            }

            SetBoxStyling();
            var requestDto = CreateSmitenightProcessRequest();
            var response = await HttpClient.PostAsJsonAsync(SmitenightEndpoints.EndSmitenight, requestDto, CancellationToken.None);
            if (!response.IsSuccessStatusCode)
            {
                SmitenightErrorAlertMessage = "Something went wrong";
                await SmitenightErrorAlert.Show();
            }
            else
            {
                SmitenightSuccessAlertMessage = "Smitenight ended!";
                await SmitenightSuccessAlert.Show();
            }

            UndoBoxStyling();
        }

        private SmitenightProcessRequestDto CreateSmitenightProcessRequest()
        {
            return new SmitenightProcessRequestDto
            {
                PlayerName = _smitenightProcessModel.PlayerName,
                PassCode = _smitenightProcessModel.PinCode
            };
        }

        private void SetBoxStyling()
        {
            FormStyle = "opacity: 0.2";
            ButtonStyle = "display: none";
            LoaderStyle = "display: block";
        }

        private void UndoBoxStyling()
        {
            FormStyle = string.Empty;
            ButtonStyle = string.Empty;
            LoaderStyle = "display: none";
        }
    }
}
