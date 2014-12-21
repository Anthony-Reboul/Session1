using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using TAL.Core.Interface;
using TAL.Core.Behavior;
using Android.Graphics;
using System.Net;
using TAL.Core.Entity;

namespace TAL.Droid
{
    [Activity(Label = "TAL.Droid", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity, SpecificInterface
    {
        private UserBehavior _behavior;

        private bool _isLiking;

        private TextView _likeCount;
        private TextView _profileName;
        private Button _startStopButton;
        private ImageView _profileImage;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.Main);

            // TODO Add user facebook id and token
            User user = new User("", "");
            _behavior = new UserBehavior(user, this);
            
            _isLiking = false;

            _likeCount = FindViewById<TextView>(Resource.Id.like_count);
            _profileName = FindViewById<TextView>(Resource.Id.contact_name);
            _profileImage = FindViewById<ImageView>(Resource.Id.contact_image);
            _startStopButton = FindViewById<Button>(Resource.Id.start_stop_button);

            _startStopButton.Click += delegate
            {
                if (_isLiking)
                {
                    _startStopButton.Text = GetString(Resource.String.StartLikingButton);
                    _behavior.StopAutoLiking();
                }
                else
                {
                    _startStopButton.Text = GetString(Resource.String.StopLikingButton);
                    _behavior.StartAutoLiking();
                }
                _isLiking = !_isLiking;
            };
        }

        private Bitmap GetImageBitmapFromUrl(string url)
        {
            Bitmap imageBitmap = null;

            using (var webClient = new WebClient())
            {
                var imageBytes = webClient.DownloadData(url);
                if (imageBytes != null && imageBytes.Length > 0)
                {
                    imageBitmap = BitmapFactory.DecodeByteArray(imageBytes, 0, imageBytes.Length);
                }
            }

            return imageBitmap;
        }

        public void SetNumberOfLikes(string numberOfLikes)
        {
            _likeCount.Text = numberOfLikes;
        }

        public void AddNewProfile(string profilePicture, string name)
        {
            Bitmap image = GetImageBitmapFromUrl(profilePicture);
            _profileImage.SetImageBitmap(image);
            _profileName.Text = name;
        }
    }
}

