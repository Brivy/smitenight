using Microsoft.AspNetCore.Components;
using SmitenightApp.Client.Interfaces;

namespace SmitenightApp.Client.Components.Home
{
    public partial class GodBubbles
    {
        private List<string> GodBubbleStyles { get; set; } = new();

        [Inject] private IGodClient GodClient { get; set; } = null!;

        protected override async Task OnInitializedAsync()
        {
            var gods = await GodClient.ListHomeLoadingSkinsAsync();
            if (!gods.IsSuccessStatusCode || gods.Response == null)
            {
                return;
            }

            var godSkinCollection = gods.Response.Where(x => !string.IsNullOrWhiteSpace(x.GodSkinUrl)).Select(x => x.GodSkinUrl).ToList();
            var delay = 0;
            var random = new Random();
            var previousRandomLefts = new List<int>();
            foreach (var godCard in godSkinCollection)
            {
                var randomLeft = random.Next(0, 75);
                while (previousRandomLefts.Any(x => x - 2 <= randomLeft && x + 2 >= randomLeft))
                {
                    randomLeft = random.Next(0, 70);
                }

                previousRandomLefts.Add(randomLeft);
                var randomTimer = random.Next(40, 60);
                var randomTop = random.Next(50, 60);
                var randomScale = random.Next(20, 40);
                var styling = $"content:url(\"{godCard}\"); " +
                              $"opacity: 0; " +
                              $"-webkit-animation: godsAnimation {randomTimer}s linear {delay}s infinite; " +
                              $"-moz-animation: godsAnimation {randomTimer}s linear {delay}s infinite; " +
                              $"animation: godsAnimation {randomTimer}s linear {delay}s infinite; " +
                              $"left: {randomLeft}%; " +
                              $"top: {randomTop}%; " +
                              $"-webkit-transform: scale(0.{randomScale}); " +
                              $"-moz-transform: scale(0.{randomScale}); " +
                              $"transform: scale(0.{randomScale});";
                GodBubbleStyles.Add(styling);
                delay += 5;
            }
        }
    }
}
