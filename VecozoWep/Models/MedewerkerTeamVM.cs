using BusnLogicVecozo;
using DALMSSQL;
using VecozoWep.Models;

namespace VecozoWeb.Models
{
    public class MedewerkerTeamVM
    {
        public MedewerkerVM MedewerkerVM { get; set; }
        public List<MedewerkerVM> MedewerkersVM { get; set; } = new List<MedewerkerVM>();
        public TeamVM TeamVM { get; set; }

        public MedewerkerTeamVM(MedewerkerVM medewerkerVM, List<MedewerkerVM> medewerkersVM, TeamVM teamVM)
        {
            this.MedewerkerVM = medewerkerVM;
            this.MedewerkersVM = medewerkersVM;
            this.TeamVM = teamVM;
        }

        public MedewerkerTeamVM()
        {

        }

        public List<int> CheckOfMedewerkerInTeamZit(int teamID)
        {
            TeamContainer tc = new TeamContainer(new TeamDAL());
            List<int> Medewerkersinteam = new List<int>();
            List<Medewerker> medewerkers = tc.GetMedewerkersFromTeam(teamID);
            List<MedewerkerVM> vms = new List<MedewerkerVM>();
            foreach (Medewerker medewerker in medewerkers)
            {
                vms.Add(new MedewerkerVM(medewerker));
            }
            foreach (MedewerkerVM medewerkerVM in vms)
            {
                Medewerkersinteam.Add(medewerkerVM.UserID);
            }
            return Medewerkersinteam;
        }
    }
}
