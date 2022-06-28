using SongProject.EF;
using SongProject.Models;
using SongProject.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SongProject
{
    public partial class Form1 : Form
    {
        UnitOfWork unitOfWork;
        SongContext _db;
        public Form1()
        {
            _db = new SongContext("databasesss");
            unitOfWork = new UnitOfWork(new AlbumRepository(_db), new PlaylistRepository(_db), new SingerRepository(_db), new SongRepository(_db));
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    if (textBox1.Text == "")
            //    {
            //        MessageBox.Show("ERROR\nempty blank");
            //    }
            //    else
            //    {
            //        unitOfWork.SingerRepository.Add(new Singer { Albums = new List<Album>(), Name = textBox1.Text, Songs = new List<Song>() });
            //        textBox1.Text = "";
            //        _db.SaveChanges();
            //        MessageBox.Show("Done!");
            //    }

            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
            if (textBox1.Text == "")
            {
                MessageBox.Show("ERROR\nempty blank");
            }
            else
            {
                unitOfWork.SongRepository.Add(new Song(textBox1.Text, unitOfWork.SingerRepository.GetAll()[0]));
                textBox1.Text = "";
                _db.SaveChanges();
                MessageBox.Show("Done!");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                MessageBox.Show("ERROR\nempty blank");
            }
            unitOfWork.SongRepository.Delete(unitOfWork.SongRepository.Get(Convert.ToInt32(textBox2.Text)));
            textBox2.Text = "";
            _db.SaveChanges();
            MessageBox.Show("Done!");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox3.Text == "" || textBox4.Text == "")
                {
                    MessageBox.Show("ERROR\nempty blank");
                }
                unitOfWork.SongRepository.Update(new Song(Convert.ToInt32(textBox3.Text), textBox4.Text));
                textBox3.Text = "";
                textBox4.Text = "";
                _db.SaveChanges();
                MessageBox.Show("Done!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string res = "";
            foreach (var item in unitOfWork.SongRepository.GetAll())
            {
                res += "Id: " + item.Id + ". Name: " + item.Name + "\n" + "SingerId: " + item.Singer.Id + ". Siinger`s name: " + item.Singer.Name+ "\n";
            }
            MessageBox.Show(res);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox5.Text == "")
                {
                    MessageBox.Show("ERROR\nempty blank");
                }
                else
                {
                    unitOfWork.SingerRepository.Add(new Singer { Albums = new List<Album>(), Name = textBox5.Text, Songs = new List<Song>() });
                    textBox5.Text = "";
                    _db.SaveChanges();
                    MessageBox.Show("Виконано!");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox6.Text == "")
                {
                    MessageBox.Show("ERROR\nempty blank");
                }
                else
                {
                    unitOfWork.SingerRepository.Delete(unitOfWork.SingerRepository.Get(Convert.ToInt32(textBox6.Text)));
                    textBox6.Text = "";
                    _db.SaveChanges();
                    MessageBox.Show("Виконано!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox7.Text == "" || textBox8.Text == "")
                {
                    MessageBox.Show("ERROR\nempty blank");
                }
                else
                {
                    unitOfWork.SingerRepository.Update(new Singer { Id = Convert.ToInt32(textBox7.Text), Name = textBox8.Text });
                    textBox7.Text = ""; textBox8.Text = "";
                    _db.SaveChanges();
                    MessageBox.Show("Виконано!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox9.Text == "" || textBox10.Text == "")
                {
                    MessageBox.Show("ERROR\nempty blank");
                }
                else
                {
                    unitOfWork.SingerRepository.AddSongToSinger(Convert.ToInt32(textBox9.Text), Convert.ToInt32(textBox10.Text));
                    textBox9.Text = ""; textBox10.Text = "";
                    _db.SaveChanges();
                    MessageBox.Show("Виконано!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        
        private void button9_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox11.Text == "" || textBox12.Text == "")
                {
                    MessageBox.Show("ERROR\nempty blank");
                }
                else
                {
                    unitOfWork.SingerRepository.DeleteSongFromSinger(Convert.ToInt32(textBox11.Text), Convert.ToInt32(textBox12.Text));
                    textBox11.Text = ""; textBox12.Text = "";
                    _db.SaveChanges();
                    MessageBox.Show("Виконано!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            string res = "";
            foreach (var item in unitOfWork.SingerRepository.GetAll())
            {
                res += "Id: " + item.Id + ". Name: " + item.Name + "\n";
                res += "Albums:\n";
                foreach (var album in item.Albums)
                {
                    res += "Album Id: " + album.Id + ". Name: " + album.Name + "\n";
                }
                res += "Songs:\n";
                foreach (var song in item.Songs)
                {
                    res += "Song Id: " + song.Id + ". Name: " + song.Name + "\n";
                }
            }
            MessageBox.Show(res);
        }

        private void button16_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox20.Text == "")
                {
                    MessageBox.Show("ERROR\nempty blank");
                }
                else
                {
                    unitOfWork.PlaylistRepository.Add(new Playlist(textBox20.Text));
                    textBox20.Text = "";
                    _db.SaveChanges();
                    MessageBox.Show("Done!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox19.Text == "")
                {
                    MessageBox.Show("ERROR\nempty blank");
                }
                else
                {
                    unitOfWork.PlaylistRepository.Delete(unitOfWork.PlaylistRepository.Get(Convert.ToInt32(textBox19.Text)));
                    textBox19.Text = "";
                    _db.SaveChanges();
                    MessageBox.Show("Done!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox17.Text == "" || textBox18.Text == "")
                {
                    MessageBox.Show("ERROR\nempty blank");
                }
                else
                {
                    unitOfWork.PlaylistRepository.Update(new Playlist(Convert.ToInt32(textBox17.Text), textBox18.Text));
                    textBox17.Text = ""; textBox18.Text = "";
                    _db.SaveChanges();
                    MessageBox.Show("Done!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

            }

        private void textBox17_TextChanged(object sender, EventArgs e)
        {

        }

        private void button13_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox15.Text == "" || textBox16.Text == "")
                {
                    MessageBox.Show("ERROR\nempty blank");
                }
                else
                {
                    unitOfWork.PlaylistRepository.AddSongToPlaylist(Convert.ToInt32(textBox16.Text), Convert.ToInt32(textBox15.Text));
                    textBox15.Text = ""; textBox16.Text = "";
                    _db.SaveChanges();
                    MessageBox.Show("Done!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox14.Text == "" || textBox13.Text == "")
                {
                    MessageBox.Show("ERROR\nempty blank");
                }
                else
                {
                    unitOfWork.PlaylistRepository.DeleteSongFromPlaylist(Convert.ToInt32(textBox13.Text), Convert.ToInt32(textBox14.Text));
                    textBox14.Text = ""; textBox13.Text ="";
                    _db.SaveChanges();
                    MessageBox.Show("Done!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            string res = "";
            foreach (var item in unitOfWork.PlaylistRepository.GetAll())
            {
                res += "Id: " + item.Id + ". Name: " + item.Name + "\n";
                res += "Songs:\n";
                foreach (var song in item.Songs)
                {
                    res += "Song Id: " + song.Id + ". Song Name: " + song.Name + "\n";
                    res += "Singer Id: " + song.Singer.Id + ". Singer Name: " + song.Singer.Name + "\n";
                }
            }
            MessageBox.Show(res);
        }

        private void button22_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox28.Text == "" || textBox29.Text == "")
                {
                    MessageBox.Show("ERROR\nempty blank");
                }
                else
                {
                    unitOfWork.AlbumRepository.Add(new Album(textBox28.Text, unitOfWork.SingerRepository.Get(Convert.ToInt32(textBox29.Text))));
                    textBox28.Text = ""; textBox29.Text = "";
                    _db.SaveChanges();
                    MessageBox.Show("Done!");
                }
            }   
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button21_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox27.Text == "")
                {
                    MessageBox.Show("ERROR\nempty blank");
                }
                else
                {
                    unitOfWork.AlbumRepository.Delete(unitOfWork.AlbumRepository.Get(Convert.ToInt32(textBox27.Text)));
                    textBox27.Text = "";
                    _db.SaveChanges();
                    MessageBox.Show("Done!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button20_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox25.Text == "" || textBox26.Text == "")
                {
                    MessageBox.Show("ERROR\nempty blank");
                }
                else
                {
                    unitOfWork.AlbumRepository.Update(new Album(Convert.ToInt32(textBox25.Text),textBox26.Text));
                    textBox25.Text = ""; textBox26.Text = "";
                    _db.SaveChanges();
                    MessageBox.Show("Done!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button19_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox23.Text == "" || textBox24.Text == "")
                {
                    MessageBox.Show("ERROR\nempty blank");
                }
                else
                {
                    unitOfWork.AlbumRepository.AddSongToAlbum(Convert.ToInt32(textBox24.Text), Convert.ToInt32(textBox23.Text));
                    textBox23.Text = ""; textBox24.Text = "";
                    _db.SaveChanges();
                    MessageBox.Show("Done!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button18_Click(object sender, EventArgs e)
        {

            try
            {
                if (textBox21.Text == "" || textBox22.Text == "")
                {
                    MessageBox.Show("ERROR\nempty blank");
                }
                else
                {
                    unitOfWork.AlbumRepository.DeleteSongFromAlbum(Convert.ToInt32(textBox22.Text), Convert.ToInt32(textBox21.Text));
                    textBox21.Text = ""; textBox22.Text = "";
                    _db.SaveChanges();
                    MessageBox.Show("Done!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button17_Click(object sender, EventArgs e)
        {
            string res = "";
            foreach (var album in unitOfWork.AlbumRepository.GetAll())
            {
                res += "Id: " + album.Id + ". Name: " + album.Name + "\n";
                res += "Singer Id: " + album.Singer.Id + ". Singer Name: " + album.Singer.Name + "\nSongs:\n";
                foreach (var item in album.Songs)
                {
                    res += "Song Id: " + item.Id + ". Song Name: " + item.Name + "\n";
                }
            }
            MessageBox.Show(res);
        }

        private void tabPage4_Click(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }
    }
}
