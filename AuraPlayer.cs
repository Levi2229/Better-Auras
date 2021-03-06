﻿using MoreAuras.Projectiles;
using MoreAuras.Values;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using static Terraria.ModLoader.ModContent;

namespace MoreAuras
{
    class AuraPlayer : ModPlayer
    {
        public AuraModProjectile stevesRock;
        public AuraModProjectile spikedRock;
        public AuraModProjectile vileRock;
        public AuraModProjectile burningRock;
        public AuraModProjectile ghastlyRock;
        public AuraModProjectile moonCore;
        public AuraModProjectile homingBullet;

        public override void ResetEffects()
        {
            stevesRock.isActive = false;
            spikedRock.isActive = false;
            vileRock.isActive = false;
            burningRock.isActive = false;
            ghastlyRock.isActive = false;
            moonCore.isActive = false;
            homingBullet.isActive = false;
        }

        public override void Initialize()
        {
            //Apparently constructors inside of anything that inherits from ModProjectile breaks it..
            stevesRock = new StevesRockAura();
            stevesRock.speed = AuraSpeeds.Slowest;
            stevesRock.amount = AuraCount.Lowest;
            stevesRock.damage = AuraDamage.Lowest;
            stevesRock.knockback = 0;

            spikedRock = new SpikedRockAura();
            spikedRock.speed = AuraSpeeds.Slow;
            spikedRock.amount = AuraCount.Lowest;
            spikedRock.damage = AuraDamage.VeryLow;
            spikedRock.knockback = 0;

            vileRock = new VileRockAura();
            vileRock.speed = AuraSpeeds.Medium;
            vileRock.amount = AuraCount.Low;
            vileRock.damage = AuraDamage.Low;
            vileRock.knockback = 0;

            burningRock = new BurningRockAura();
            burningRock.speed = AuraSpeeds.Rapid;
            burningRock.amount = AuraCount.Medium;
            burningRock.damage = AuraDamage.Medium;
            burningRock.knockback = 0;

            ghastlyRock = new GhastlyRockAura();
            ghastlyRock.speed = AuraSpeeds.Fast;
            ghastlyRock.amount = AuraCount.VeryHigh;
            ghastlyRock.damage = AuraDamage.Medium;
            ghastlyRock.knockback = 0;

            moonCore = new MoonCoreAura();
            moonCore.speed = AuraSpeeds.Flash;
            moonCore.amount = AuraCount.High;
            moonCore.damage = AuraDamage.Insane;
            moonCore.knockback = 0;

            homingBullet = new HomingBulletAura();
            homingBullet.speed = 300;
            homingBullet.amount = AuraCount.Low;
            homingBullet.damage = AuraDamage.High;
            homingBullet.knockback = 0;
        }

        public override void PostUpdateEquips()
        {
            if (stevesRock.isActive && stevesRock.instanceIds.Count < stevesRock.amount)
            {
                for (int i = 0; i < stevesRock.amount; i++)
                {
                    int stevesRockInstanceId = Projectile.NewProjectile(
                  player.Center.X,
                  player.Center.Y,
                  stevesRock.speed,
                  0f,
                  ProjectileType<StevesRockAura>(),
                  stevesRock.damage,
                  stevesRock.knockback,
                  Main.myPlayer,
                  player.whoAmI,
                  0);
                    stevesRock.instanceIds.Add(stevesRockInstanceId);
                    Main.projectile[stevesRockInstanceId].localAI[0] = 50;
                    Main.projectile[stevesRockInstanceId].localAI[1] = 1;
                    NetMessage.SendData(27, -1, -1, null, stevesRockInstanceId);
                }
            }

            if (spikedRock.isActive && spikedRock.instanceIds.Count < spikedRock.amount)
            {
                int spikedRockInstanceId = Projectile.NewProjectile(
                          player.Center.X,
                          player.Center.Y,
                          spikedRock.speed,
                          0f,
                          ProjectileType<SpikedRockAura>(),
                          spikedRock.damage,
                          spikedRock.knockback,
                          Main.myPlayer,
                          player.whoAmI,
                          0);
                spikedRock.instanceIds.Add(spikedRockInstanceId);
                Main.projectile[spikedRockInstanceId].localAI[0] = (int)AuraRadius.Small;
                Main.projectile[spikedRockInstanceId].localAI[1] = 1;
                NetMessage.SendData(27, -1, -1, null, spikedRockInstanceId);

            }

            if (vileRock.isActive && vileRock.instanceIds.Count < vileRock.amount)
            {

                Random rnd = new Random();
                for (int i = 0; i < vileRock.amount; i++)
                {
                    int randomInt = rnd.Next(0, 360);
                    int vileRockInstanceId = Projectile.NewProjectile(
                                player.Center.X,
                                player.Center.Y,
                                0,
                                0,
                                ProjectileType<VileRockAura>(),
                                vileRock.damage,
                                vileRock.knockback,
                                Main.myPlayer,
                                player.whoAmI, 
                                randomInt
                               );
                    vileRock.instanceIds.Add(vileRockInstanceId);
                    Main.projectile[vileRockInstanceId].localAI[0] = (int)AuraRadius.Medium;
                    int clockwise = i % 2;
                    Main.projectile[vileRockInstanceId].localAI[1] = clockwise != 0 ? 1 : -1;
                    NetMessage.SendData(27, -1, -1, null, vileRockInstanceId);
                }
            }

            if (burningRock.isActive && burningRock.instanceIds.Count < burningRock.amount)
            {
                Random rnd = new Random();
                for (int i = 0; i < burningRock.amount; i++)
                {
                    int randomInt = rnd.Next(0, 360);
                    int burningRockInstanceId = Projectile.NewProjectile(
                                player.Center.X,
                                player.Center.Y,
                                0,
                                0,
                                ProjectileType<BurningRockAura>(),
                                burningRock.damage,
                                burningRock.knockback,
                                Main.myPlayer,
                                player.whoAmI,
                                randomInt
                               );
                    burningRock.instanceIds.Add(burningRockInstanceId);
                    Main.projectile[burningRockInstanceId].localAI[0] = (int)AuraRadius.Large;
                    int clockwise = i % 2;
                    Main.projectile[burningRockInstanceId].localAI[1] = clockwise != 0 ? 1 : -1;
                    NetMessage.SendData(27, -1, -1, null, burningRockInstanceId);
                }
            }

            if (ghastlyRock.isActive && ghastlyRock.instanceIds.Count < ghastlyRock.amount)
            {

                Random rnd = new Random();
                for (int i = 0; i < ghastlyRock.amount; i++)
                {
                    int randomInt = rnd.Next(0, 360);
                    int ghastlyRockkInstanceId = Projectile.NewProjectile(
                                player.Center.X,
                                player.Center.Y,
                                0,
                                0,
                                ProjectileType<GhastlyRockAura>(),
                                ghastlyRock.damage,
                                ghastlyRock.knockback,
                                Main.myPlayer,
                                player.whoAmI,
                                randomInt
                               );
                    ghastlyRock.instanceIds.Add(ghastlyRockkInstanceId);
                    Main.projectile[ghastlyRockkInstanceId].localAI[0] = (int)AuraRadius.Huge;
                    int clockwise = i % 2;
                    Main.projectile[ghastlyRockkInstanceId].localAI[1] = clockwise != 0 ? 1 : -1;
                    NetMessage.SendData(27, -1, -1, null, ghastlyRockkInstanceId);
                }
            }
            if (moonCore.isActive && moonCore.instanceIds.Count < moonCore.amount)
            {

                Random rnd = new Random();
                for (int i = 0; i < moonCore.amount; i++)
                {
                    int randomInt = rnd.Next(0, 360);
                    int moonCoreInstanceId = Projectile.NewProjectile(
                                player.Center.X,
                                player.Center.Y,
                                0,
                                0,
                                ProjectileType<MoonCoreAura>(),
                                moonCore.damage,
                                moonCore.knockback,
                                Main.myPlayer,
                                player.whoAmI,
                                randomInt
                               );
                    moonCore.instanceIds.Add(moonCoreInstanceId);
                    Main.projectile[moonCoreInstanceId].localAI[0] = (int)AuraRadius.Space;
                    int clockwise = i % 2;
                    Main.projectile[moonCoreInstanceId].localAI[1] = clockwise != 0 ? 1 : -1;
                    NetMessage.SendData(27, -1, -1, null, moonCoreInstanceId);
                }
            }
            if (homingBullet.isActive && homingBullet.instanceIds.Count < homingBullet.amount)
            {

                Random rnd = new Random();
                for (int i = 0; i < homingBullet.amount; i++)
                {
                    int randomInt = rnd.Next(0, 360);
                    int homingBulletInstanceId = Projectile.NewProjectile(
                                player.Center.X,
                                player.Center.Y,
                                0,
                                0,
                                ProjectileType<HomingBulletAura>(),
                                homingBullet.damage,
                                homingBullet.knockback,
                                Main.myPlayer,
                                player.whoAmI,
                                randomInt
                               );
                    homingBullet.instanceIds.Add(homingBulletInstanceId);
                    Main.projectile[homingBulletInstanceId].localAI[0] = (int)AuraRadius.Space;
                    int clockwise = i % 2;
                    Main.projectile[homingBulletInstanceId].localAI[1] = clockwise != 0 ? 1 : -1;
                    NetMessage.SendData(27, -1, -1, null, homingBulletInstanceId);
                }
            }
        }


        public override void UpdateEquips(ref bool wallSpeedBuff, ref bool tileSpeedBuff, ref bool tileRangeBuff)
        {
            if (!stevesRock.isActive)
            {
                foreach (int instanceid in stevesRock.instanceIds)
                {
                    Main.projectile[instanceid].Kill();
                }
                stevesRock.instanceIds = new List<int>();
            }
            if (!spikedRock.isActive)
            {
                foreach (int instanceid in spikedRock.instanceIds)
                {
                    Main.projectile[instanceid].Kill();
                }
                spikedRock.instanceIds = new List<int>();
            }
            if (!vileRock.isActive)
            {
                foreach (int instanceid in vileRock.instanceIds)
                {
                    Main.projectile[instanceid].Kill();
                }
                vileRock.instanceIds = new List<int>();
            }
            if (!burningRock.isActive)
            {
                foreach (int instanceid in burningRock.instanceIds)
                {
                    Main.projectile[instanceid].Kill();
                }
                burningRock.instanceIds = new List<int>();
            }
            if (!ghastlyRock.isActive)
            {
                foreach (int instanceid in ghastlyRock.instanceIds)
                {
                    Main.projectile[instanceid].Kill();
                }
                ghastlyRock.instanceIds = new List<int>();
            }
            if (!moonCore.isActive)
            {
                foreach (int instanceid in moonCore.instanceIds)
                {
                    Main.projectile[instanceid].Kill();
                }
                moonCore.instanceIds = new List<int>();
            }
            if (!homingBullet.isActive)
            {
                foreach (int instanceid in homingBullet.instanceIds)
                {
                    Main.projectile[instanceid].Kill();
                }
                homingBullet.instanceIds = new List<int>();
            }
        }
        public override void Kill(double damage, int hitDirection, bool pvp, PlayerDeathReason damageSource)
        {
            this.ResetEffects();
        }
    }
}
