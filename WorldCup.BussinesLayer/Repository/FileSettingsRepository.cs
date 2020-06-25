using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using WorldCup.BussinesLayer.Models;
using WorldCup.BussinesLayer.ViewModels;

namespace WorldCup.BussinesLayer.Repository
{
	public interface ISettingsRepository
	{
		GetSettingsTaskResponse GetSettingsTask();
		SaveSettingsTaskResponse SaveSettingsTask(SaveSettingsTaskRequest request);
	}

	public class FileSettingsRepository : ISettingsRepository
	{
		public SaveSettingsTaskResponse SaveSettingsTask(SaveSettingsTaskRequest request)
		{
			using (StreamWriter sw = new StreamWriter(PathsConstants.SettingsFilePath))
			{
				var newSettings = request.Settings;

				var json = JsonConvert.SerializeObject(newSettings);
				sw.Write(json);
			}

			return new SaveSettingsTaskResponse();
		}

		public GetSettingsTaskResponse GetSettingsTask()
		{
			if (!File.Exists(PathsConstants.SettingsFilePath))
			{
				File.Create(PathsConstants.SettingsFilePath).Dispose();
			}
			using (StreamReader sr = new StreamReader(PathsConstants.SettingsFilePath))
			{
				SettingsModel settings = JsonConvert.DeserializeObject<SettingsModel>(sr.ReadToEnd());				

				if(settings == null)
				{
					return new GetSettingsTaskResponse()
					{
						Succeded = false
					};
				}

				return new GetSettingsTaskResponse()
				{
					Settings = settings
				};
			}
		}

	}

	public class GetSettingsTaskResponse
	{
		public bool Succeded { get; set; } = true;
		public SettingsModel Settings { get; set; }
	}

	public class SaveSettingsTaskRequest
	{
		public SettingsModel Settings { get; set; }
	}
	public class SaveSettingsTaskResponse
	{
		public bool Succeded { get; set; } = true;
	}
}
