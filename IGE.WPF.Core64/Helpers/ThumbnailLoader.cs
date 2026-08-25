using System;
using System.Collections.Concurrent;
using System.Threading;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using IGE.Parameters;

namespace IGE.Helpers
{
	// Token: 0x02000395 RID: 917
	internal sealed class ThumbnailLoader
	{
		// Token: 0x1700027E RID: 638
		// (get) Token: 0x0600149A RID: 5274 RVA: 0x0002BD19 File Offset: 0x00029F19
		public static ThumbnailLoader Instance
		{
			get
			{
				return ThumbnailLoader.lazy.Value;
			}
		}

		// Token: 0x0600149B RID: 5275 RVA: 0x0002BD25 File Offset: 0x00029F25
		private ThumbnailLoader()
		{
			this._thread = new Thread(new ThreadStart(this.ProcessJobs));
			this._thread.Start();
		}

		// Token: 0x0600149C RID: 5276 RVA: 0x0002BD61 File Offset: 0x00029F61
		public void Shutdown()
		{
			this.m_run = false;
			ThumbnailLoader._jobRegisteredEvent.Set();
		}

		// Token: 0x0600149D RID: 5277 RVA: 0x0002BD75 File Offset: 0x00029F75
		public void ResolveThumbnail(InventoryEntryViewModel entry)
		{
			this._jobQueue.Enqueue(entry);
			ThumbnailLoader._jobRegisteredEvent.Set();
		}

		// Token: 0x0600149E RID: 5278 RVA: 0x0002BDBC File Offset: 0x00029FBC
		private void ProcessJobs()
		{
			while (this.m_run)
			{
				InventoryEntryViewModel job = null;
				if (!this._jobQueue.TryDequeue(out job))
				{
					ThumbnailLoader._jobRegisteredEvent.WaitOne();
				}
				if (job != null)
				{
					BitmapFrame thumbnail = job.Model.GetThumbnail();
					if (thumbnail != null)
					{
						int num = 100;
						int num2;
						int num3;
						if (thumbnail.Width > thumbnail.Height)
						{
							num2 = num;
							num3 = (int)(thumbnail.Height * (double)num / thumbnail.Width);
						}
						else
						{
							num3 = num;
							num2 = (int)(thumbnail.Width * (double)num / thumbnail.Height);
						}
						TransformedBitmap source = new TransformedBitmap(thumbnail, new ScaleTransform((double)num2 / thumbnail.Width, (double)num3 / thumbnail.Height, 0.0, 0.0));
						Freezable result = BitmapFrame.Create(source).GetAsFrozen();
						Application.Current.Dispatcher.BeginInvoke(new Action(delegate()
						{
							job.Image = (BitmapFrame)result;
						}), new object[0]);
					}
				}
			}
		}

		// Token: 0x0400078A RID: 1930
		private static readonly Lazy<ThumbnailLoader> lazy = new Lazy<ThumbnailLoader>(() => new ThumbnailLoader());

		// Token: 0x0400078B RID: 1931
		private static EventWaitHandle _jobRegisteredEvent = new EventWaitHandle(false, EventResetMode.AutoReset);

		// Token: 0x0400078C RID: 1932
		private ConcurrentQueue<InventoryEntryViewModel> _jobQueue = new ConcurrentQueue<InventoryEntryViewModel>();

		// Token: 0x0400078D RID: 1933
		private Thread _thread;

		// Token: 0x0400078E RID: 1934
		private bool m_run = true;
	}
}
