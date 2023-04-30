using ReactiveUI;
using Splat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Text;
using System.Threading.Tasks;

namespace MedicinePsychologicalEvaluation.ViewModels
{
    public class SelectTypeViewModel : ViewModelBase, IRoutableViewModel
    {
        public IScreen HostScreen { get; }

        public string UrlPathSegment { get; } = "/selecttype";

        public SelectTypeViewModel(IScreen screen)
        {
            HostScreen = screen ?? Locator.Current.GetService<IScreen>();
            AnxietySelf = ReactiveCommand.CreateFromObservable(
                () => HostScreen.Router.Navigate.Execute(new AnxietyOtherViewModel(HostScreen))
            );

            AnxietyOther = ReactiveCommand.CreateFromObservable(
                () => HostScreen.Router.Navigate.Execute(new AnxietyOtherViewModel(HostScreen))
            );

            DepressedSelf = ReactiveCommand.CreateFromObservable(
               () => HostScreen.Router.Navigate.Execute(new DepressedSelfViewModel(HostScreen))
           );

            DepressedOther = ReactiveCommand.CreateFromObservable(
               () => HostScreen.Router.Navigate.Execute(new DepressedOtherViewModel(HostScreen))
           );
        }

        public ReactiveCommand<Unit, IRoutableViewModel> AnxietySelf { get; }

        public ReactiveCommand<Unit, IRoutableViewModel> AnxietyOther { get; }

        public ReactiveCommand<Unit, IRoutableViewModel> DepressedSelf { get; }

        public ReactiveCommand<Unit, IRoutableViewModel> DepressedOther { get; }

    }
}
