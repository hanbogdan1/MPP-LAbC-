using P3_Mpp_Lab1.Domain;
using P3_Mpp_Lab1.Repository;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P3_Mpp_Lab1.Cntrl
{
    public class Controller
    {
        private SQLiteConnection connection;
        private ProbaRepo probaRepository;
        private ProgramareRepo programareRepository;
        private ParticipantRepo participantRepository;
        private AdminRepo adminRepository;
        public Controller(SQLiteConnection connectionn)
        {
            connection = connectionn;
            probaRepository = new ProbaRepo(connection);
            programareRepository = new ProgramareRepo(connection);
            participantRepository = new ParticipantRepo(connection);
            adminRepository = new AdminRepo(connection);
        }
        public void add_proba(Proba x) {
            if (probaRepository.exist_data(x))
                probaRepository.add(x);
             
        }
       public  SQLiteConnection get_connection()
        {
            return connection;
        }


        public void add_admin(Admin x)
        {
            if (adminRepository.can_register(x))
                adminRepository.add(x);

        }

        public void add_participant(Participant x)
        {
            if (participantRepository.exist_data(x))
                participantRepository.add(x);

        }

        public int id_of_participant(Participant x)
        {
            return participantRepository.get_id_by_details(x);
        }

        public bool find_participant(Participant x)
        {
            return participantRepository.exist_data(x);
        }

        public void add_programare(int id_participant , int id_proba)
        {
            if (programareRepository.exist_data(id_participant, id_proba))
            {
                programare x = new programare();
                x.Id_participant = id_participant;
                x.Id_proba = id_proba;
                programareRepository.add(x);
                probaRepository.increment_nr_participanti(id_proba);
            }
              
        }


        public void Update_proba(Proba x)
        {
            if (probaRepository.exist(x.id))
                probaRepository.update(x);

        }


        public void Update_admin(Admin x)
        {
            if (adminRepository.exist(x.id))
                adminRepository.update(x);

        }
        public void update_participant(Participant x)
        {
            if (participantRepository.exist(x.id))
                participantRepository.update(x);

        }

        public void update_programare(programare x)
        {
            if (programareRepository.exist(x.id))
                programareRepository.update(x);
        }


        public void delete_proba(Proba x)
        {
            if (probaRepository.exist(x.id))
                probaRepository.delete(x.id);

        }

        public void delete_participant(Participant x)
        {
            if (participantRepository.exist(x.id))
                participantRepository.delete(x.id);

        }

        public void delete_programare(programare x)
        {
            if (programareRepository.exist(x.id))
                programareRepository.delete(x.id);
        }

        public void delete_admin(Admin x)
        {
            if (adminRepository.exist(x.id))
                adminRepository.delete(x.id);

        }

        public List<Proba> get_all_probe()
        {
            return probaRepository.getAll();
        }

        public List<programare> get_all_programari()
        {
            return programareRepository.getAll();
        }
        public List<Participant> get_all_participanti()
        {
            return participantRepository.getAll();
        }
        public bool verify_login (Admin x)
        {
            return adminRepository.verify_login(x);
        }
    }
}

