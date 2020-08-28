using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace WorldCup.BussinesLayer.Models
{
    public class MatchDetail
    {
        [JsonProperty("venue")]
        public string Venue { get; set; }

        [JsonProperty("location")]
        public string Location { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("time")]
        public string Time { get; set; }

        [JsonProperty("fifa_id")]
        public string FifaId { get; set; }

        [JsonProperty("weather")]
        public Weather Weather { get; set; }

        [JsonProperty("attendance")]
        public string Attendance { get; set; }

        [JsonProperty("officials")]
        public List<string> Officials { get; set; }

        [JsonProperty("stage_name")]
        public string StageName { get; set; }

        [JsonProperty("home_team_country")]
        public string HomeTeamCountry { get; set; }

        [JsonProperty("away_team_country")]
        public string AwayTeamCountry { get; set; }

        [JsonProperty("datetime")]
        public DateTime? Datetime { get; set; }

        [JsonProperty("winner")]
        public string Winner { get; set; }

        [JsonProperty("winner_code")]
        public string WinnerCode { get; set; }

        [JsonProperty("home_team")]
        public MatchTeam HomeTeam { get; set; }

        [JsonProperty("away_team")]
        public MatchTeam AwayTeam { get; set; }

        [JsonProperty("home_team_events")]
        public List<TeamEvent> HomeTeamEvents { get; set; }

        [JsonProperty("away_team_events")]
        public List<TeamEvent> AwayTeamEvents { get; set; }

        [JsonProperty("home_team_statistics")]
        public TeamStatistics HomeTeamStatistics { get; set; }

        [JsonProperty("away_team_statistics")]
        public TeamStatistics AwayTeamStatistics { get; set; }

        [JsonProperty("last_event_update_at")]
        public DateTime? LastEventUpdateAt { get; set; }

        [JsonProperty("last_score_update_at")]
        public DateTime? LastScoreUpdateAt { get; set; }
    }

    public class Player
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("captain")]
        public bool Captain { get; set; }

        [JsonProperty("shirt_number")]
        public int ShirtNumber { get; set; }

        [JsonProperty("position")]
        public string Position { get; set; }
    }

    public class Weather
    {
        [JsonProperty("humidity")]
        public string Humidity { get; set; }

        [JsonProperty("temp_celsius")]
        public string TempCelsius { get; set; }

        [JsonProperty("temp_farenheit")]
        public string TempFarenheit { get; set; }

        [JsonProperty("wind_speed")]
        public string WindSpeed { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }
    }
       
    public class MatchTeam
    {
        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("goals")]
        public int Goals { get; set; }

        [JsonProperty("penalties")]
        public int Penalties { get; set; }
    }

    public class TeamEvent
    {
        [JsonProperty("id")]
        public int Id { get; set; }
    
        [JsonProperty("type_of_event")]
        public string TypeOfEvent { get; set; }

        [JsonProperty("player")]
        public string Player { get; set; }

        [JsonProperty("time")]
        public string Time { get; set; }
    }
       
    public class TeamStatistics
    {
        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("attempts_on_goal")]
        public int AttemptsOnGoal { get; set; }

        [JsonProperty("on_target")]
        public int OnTarget { get; set; }

        [JsonProperty("off_target")]
        public int OffTarget { get; set; }

        [JsonProperty("blocked")]
        public int Blocked { get; set; }

        [JsonProperty("corners")]
        public int Corners { get; set; }

        [JsonProperty("offsides")]
        public int Offsides { get; set; }

        [JsonProperty("ball_possession")]
        public int BallPossession { get; set; }

        [JsonProperty("pass_accuracy")]
        public int PassAccuracy { get; set; }

        [JsonProperty("num_passes")]
        public int NumPasses { get; set; }

        [JsonProperty("passes_completed")]
        public int PassesCompleted { get; set; }

        [JsonProperty("distance_covered")]
        public int DistanceCovered { get; set; }

        [JsonProperty("tackles")]
        public int Tackles { get; set; }

        [JsonProperty("clearances")]
        public int? Clearances { get; set; }

        [JsonProperty("yellow_cards")]
        public int? YellowCards { get; set; }

        [JsonProperty("red_cards")]
        public int RedCards { get; set; }

        [JsonProperty("fouls_committed")]
        public int? FoulsCommitted { get; set; }

        [JsonProperty("tactics")]
        public string Tactics { get; set; }

        [JsonProperty("starting_eleven")]
        public List<Player> StartingEleven { get; set; }

        [JsonProperty("substitutes")]
        public List<Player> Substitutes { get; set; }
    }    
}
