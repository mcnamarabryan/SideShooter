﻿using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;

namespace SideShooter
{
    public class IntakeAssets
    {
        public Image shipImage;
        public Image enemyshipImage;
        public Image[] explosion = new Image[65];

        public SoundPlayer[] soundMachine = new SoundPlayer[32];
        public int SoundCount=0;

        public IntakeAssets()
        {
            IntakeImages();
            IntakeSound();
        }

        public void IntakeImages()
        {
            shipImage = SideShooter.Properties.Resources.Spaceship_tut;
            shipImage.RotateFlip(RotateFlipType.Rotate90FlipNone);

            enemyshipImage = SideShooter.Properties.Resources.enemystarship;
            enemyshipImage.RotateFlip(RotateFlipType.Rotate270FlipY);

            IntakeExplosion();
        }

        private void IntakeExplosion()
        {

            explosion[1] = SideShooter.Properties.Resources._1;
            explosion[2] = SideShooter.Properties.Resources._2;

            explosion[3] = SideShooter.Properties.Resources._3;
            explosion[4] = SideShooter.Properties.Resources._4;
            explosion[5] = SideShooter.Properties.Resources._5;
            explosion[6] = SideShooter.Properties.Resources._6;

            explosion[7] = SideShooter.Properties.Resources._7;
            explosion[8] = SideShooter.Properties.Resources._8;
            explosion[9] = SideShooter.Properties.Resources._9;
            explosion[10] = SideShooter.Properties.Resources._10;

            explosion[11] = SideShooter.Properties.Resources._11;
            explosion[12] = SideShooter.Properties.Resources._12;
            explosion[13] = SideShooter.Properties.Resources._13;
            explosion[14] = SideShooter.Properties.Resources._14;

            explosion[15] = SideShooter.Properties.Resources._15;
            explosion[16] = SideShooter.Properties.Resources._16;
            explosion[17] = SideShooter.Properties.Resources._17;
            explosion[18] = SideShooter.Properties.Resources._18;

            explosion[19] = SideShooter.Properties.Resources._19;
            explosion[20] = SideShooter.Properties.Resources._20;
            explosion[21] = SideShooter.Properties.Resources._21;
            explosion[22] = SideShooter.Properties.Resources._22;

            explosion[23] = SideShooter.Properties.Resources._23;
            explosion[24] = SideShooter.Properties.Resources._24;
            explosion[25] = SideShooter.Properties.Resources._25;
            explosion[26] = SideShooter.Properties.Resources._26;

            explosion[27] = SideShooter.Properties.Resources._27;
            explosion[28] = SideShooter.Properties.Resources._28;
            explosion[29] = SideShooter.Properties.Resources._29;
            explosion[30] = SideShooter.Properties.Resources._30;

            explosion[31] = SideShooter.Properties.Resources._31;
            explosion[32] = SideShooter.Properties.Resources._32;
            explosion[33] = SideShooter.Properties.Resources._33;
            explosion[34] = SideShooter.Properties.Resources._34;

            explosion[35] = SideShooter.Properties.Resources._35;
            explosion[36] = SideShooter.Properties.Resources._36;
            explosion[37] = SideShooter.Properties.Resources._37;
            explosion[38] = SideShooter.Properties.Resources._38;

            explosion[39] = SideShooter.Properties.Resources._39;
            explosion[40] = SideShooter.Properties.Resources._40;
            explosion[41] = SideShooter.Properties.Resources._41;
            explosion[42] = SideShooter.Properties.Resources._42;

            explosion[43] = SideShooter.Properties.Resources._43;
            explosion[44] = SideShooter.Properties.Resources._44;
            explosion[45] = SideShooter.Properties.Resources._45;
            explosion[46] = SideShooter.Properties.Resources._46;

            explosion[47] = SideShooter.Properties.Resources._47;
            explosion[48] = SideShooter.Properties.Resources._48;
            explosion[49] = SideShooter.Properties.Resources._49;
            explosion[50] = SideShooter.Properties.Resources._50;

            explosion[51] = SideShooter.Properties.Resources._51;
            explosion[52] = SideShooter.Properties.Resources._52;
            explosion[53] = SideShooter.Properties.Resources._53;
            explosion[54] = SideShooter.Properties.Resources._54;

            explosion[55] = SideShooter.Properties.Resources._55;
            explosion[56] = SideShooter.Properties.Resources._56;
            explosion[57] = SideShooter.Properties.Resources._57;
            explosion[58] = SideShooter.Properties.Resources._58;
            explosion[59] = SideShooter.Properties.Resources._59;
            explosion[60] = SideShooter.Properties.Resources._60;
            explosion[61] = SideShooter.Properties.Resources._61;
            explosion[62] = SideShooter.Properties.Resources._62;
            explosion[63] = SideShooter.Properties.Resources._63;
            explosion[64] = SideShooter.Properties.Resources._64;
        }

        public void IntakeSound()
        {
            //1: Intro sound
            SoundCount++;
            soundMachine[SoundCount] = new SoundPlayer(SideShooter.Properties.Resources.wateranchor_action);
            soundMachine[SoundCount].LoadAsync();

            //2: Primary laser
            SoundCount++;
            soundMachine[SoundCount] = new SoundPlayer(SideShooter.Properties.Resources.laser1);
            soundMachine[SoundCount].LoadAsync();

            //3: Enemy Ship Die
            SoundCount++;
            soundMachine[SoundCount] = new SoundPlayer(SideShooter.Properties.Resources.Longshot);
            soundMachine[SoundCount].LoadAsync();

            //4: unused
            SoundCount++;
            soundMachine[SoundCount] = new SoundPlayer(SideShooter.Properties.Resources.space_part);
            soundMachine[SoundCount].LoadAsync();

            //5: Player space ship explosion
            SoundCount++;
            soundMachine[SoundCount] = new SoundPlayer(SideShooter.Properties.Resources.industry_exit);
            soundMachine[SoundCount].LoadAsync();

            //6: Game Over
            SoundCount++;
            soundMachine[SoundCount] = new SoundPlayer(SideShooter.Properties.Resources.water_magnet_off);
            soundMachine[SoundCount].LoadAsync();
        }
    }
}
