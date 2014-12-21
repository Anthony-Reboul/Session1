using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Support.Wearable.Views;
using Android.Support.V4.App;
using Android.Support.V4.View;
using Java.Interop;
using Android.Views.Animations;
using TAL.Core.Interface;
using TAL.Core.Entity;
using TAL.Core.Behavior;

namespace TAL.Wear
{
    [Activity(Label = "TAL.Wear", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity, SpecificInterface
    {
        private Button _startStopButton;
        private TextView _likeCount;
        private TextView _profileName;

        private UserBehavior _behavior;

        private bool _isLiking;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.Main);

            // TODO Add user facebook id and token
            User user = new User("", "");
            _behavior = new UserBehavior(user, this);

            _isLiking = false;

            var v = FindViewById<WatchViewStub>(Resource.Id.watch_view_stub);
            v.LayoutInflated += delegate
            {
                _likeCount = FindViewById<TextView>(Resource.Id.like_count);
                _profileName = FindViewById<TextView>(Resource.Id.profile_name);
                _startStopButton = FindViewById<Button>(Resource.Id.myButton);

                _startStopButton.Click += delegate
                {
                    if (_isLiking)
                    {
                        _behavior.StopAutoLiking();
                        _startStopButton.Text = GetString(Resource.String.StartLikingButton);
                    }
                    else
                    {
                        _behavior.StartAutoLiking();
                        _startStopButton.Text = GetString(Resource.String.StopLikingButton);
                    }
                    _isLiking = !_isLiking;
                };
            };
        }

        public void SetNumberOfLikes(string numberOfLikes)
        {
            _likeCount.Text = numberOfLikes;
        }

        public void AddNewProfile(string profilePicture, string name)
        {
            _profileName.Text = name;
        }
    }
}


