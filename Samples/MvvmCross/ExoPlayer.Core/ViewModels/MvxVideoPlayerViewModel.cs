﻿using System.Threading.Tasks;
using MvvmCross.ExoPlayer.Models;
using MvvmCross.Core.ViewModels;

namespace MvvmCross.ExoPlayer.ViewModels
{
	public abstract class MvxVideoPlayerViewModel : MvxViewModel, IMvxVideoPlayerViewModel
	{
		private bool _loadingItem;
		private MvxVideoItem _videoItem;

		public bool LoadingItem
		{
			get { return _loadingItem; }
			protected set { SetProperty(ref _loadingItem, value); }
		}

		public MvxVideoItem VideoItem
		{
			get { return _videoItem; }
			protected set { SetProperty(ref _videoItem, value); }
		}

		/// <summary>
		/// Call this from your Init method
		/// </summary>
		protected virtual async Task InitVideoItem()
		{
			LoadingItem = true;
			try
			{
				VideoItem = await LoadVideoItem();
			}
			finally
			{
				LoadingItem = false;
			}
		}

		protected abstract Task<MvxVideoItem> LoadVideoItem();
	}
}