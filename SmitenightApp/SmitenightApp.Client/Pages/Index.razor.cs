using System.Net.Http.Json;
using Blazorise;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using SmitenightApp.Client.Forms.Smitenights;
using SmitenightApp.Domain.Contracts.Smitenights;

namespace SmitenightApp.Client.Pages
{
    public partial class Index
    {
        private async Task StartSmitenightAsync()
        {
            var requestDto = new SmitenightProcessResponseDto
            {
                PlayerName = _smitenightProcessModel.PlayerName,
                PassCode = _smitenightProcessModel.PassCode
            };

            var response = await HttpClient.PostAsJsonAsync("Smitenight/start", requestDto, CancellationToken.None);
            if (!response.IsSuccessStatusCode)
            {
                SmitenightErrorAlertMessage = "Something went wrong";
                await SmitenightErrorAlert.Show();
            }
            else
            {
                SmitenightErrorAlertMessage = "Smitenight started!";
                await SmitenightSuccessAlert.Show();
            }
        }

        private async Task EndSmitenightAsync()
        {
            var requestDto = new SmitenightProcessResponseDto
            {
                PlayerName = _smitenightProcessModel.PlayerName,
                PassCode = _smitenightProcessModel.PassCode
            };

            var response = await HttpClient.PostAsJsonAsync("Smitenight/end", requestDto, CancellationToken.None);
            if (!response.IsSuccessStatusCode)
            {
                SmitenightErrorAlertMessage = "Something went wrong";
                await SmitenightErrorAlert.Show();
            }
            else
            {
                SmitenightErrorAlertMessage = "Smitenight ended!";
                await SmitenightSuccessAlert.Show();
            }
        }

        private Alert SmitenightSuccessAlert { get; set; } = null!;
        private string? SmitenightSuccessAlertMessage { get; set; }
        private Alert SmitenightErrorAlert { get; set; } = null!;
        private string? SmitenightErrorAlertMessage { get; set; }

        private readonly SmitenightProcessModel _smitenightProcessModel = new();

        [Inject] private HttpClient HttpClient { get; set; } = null!;
    }
}
