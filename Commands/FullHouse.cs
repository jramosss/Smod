using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using System.Collections.Generic;
using System;
namespace Smod.Commands {
    public static class NpcRequisites {
        public static bool dryad = (NPC.downedBoss1 ||NPC.downedBoss2 || NPC.downedBoss3 || NPC.downedMechBossAny);
        public static bool Clothier = NPC.downedBoss3;
        public static bool Mechanic = NPC.savedMech && NPC.downedBoss3;
        public static bool Tinkerer = NPC.downedBoss3 && NPC.savedGoblin && NPC.downedGoblins;
        public static bool WitchDoctor = NPC.downedQueenBee;
        public static bool Stylist = NPC.savedStylist;
        public static bool Angler = NPC.savedAngler;
        public static bool Wizard = NPC.savedWizard;
        public static bool SteamPunker = NPC.downedMechBossAny;
        public static bool Ciborg = NPC.downedPlantBoss;
        public static bool Pirate = NPC.downedPirates;
        public static bool TaxesCollector = NPC.taxCollector;
        public static bool Git = Main.LocalPlayer.townNPCs >= 10 && Main.LocalPlayer.HasItem(ModContent.ItemType<Items.Weapons.UltraShark>()) 
                                 || Main.LocalPlayer.HasItem(ItemID.CellPhone);
        //public static bool Truffle =  NPC.spawn
        public static bool  IsChristmas () {
            DateTime date = DateTime.Now;
            return (date.Month == 12 && date.Day == 25);
        }
        public static bool Santa = NPC.downedFrost && IsChristmas();
        public static bool Nurse (Player player) {
            return (player.statLifeMax > 100);
        }
        public static bool DyeTrader (Player player) {
            return (player.HasItem(ItemID.StrangePlant1) ||player.HasItem(ItemID.StrangePlant2) || player.HasItem(ItemID.StrangePlant3) ||player.HasItem(ItemID.StrangePlant4) || NPC.downedBoss1 ||NPC.downedBoss2 || NPC.downedBoss3);
        }
        public static bool ArmsDealer (Player player) {
            for (int i = 0; i < player.inventory.Length ; i++) {
                if (player.inventory[i].ammo == AmmoID.Bullet || Main.player[i].inventory[i].useAmmo == AmmoID.Bullet) {
                        return true;
                    }
            }
            return false;
        }
        public static bool Demolitionist (Player player) {
            return (player.HasItem(ItemID.Bomb) 
                || player.HasItem(ItemID.Explosives) 
                || player.HasItem(ItemID.StickyBomb) 
                || player.HasItem(ItemID.StickyDynamite) 
                || player.HasItem(ItemID.StickyGrenade) 
                || player.HasItem(ItemID.Grenade) 
                || player.HasItem(ItemID.BombFish) 
                || player.HasItem(ItemID.BouncyBomb) 
                || player.HasItem(ItemID.BouncyDynamite) 
                || player.HasItem(ItemID.BouncyGrenade)); 
        }
        public static bool Painter (Player player) {
            return (player.townNPCs > 6);
        }
        public static bool PartyGirl (Player player) {
            return (player.townNPCs > 12);
        }
    }
    public class FullHouse : ModCommand {
        delegate bool NpcReq();
        public override CommandType Type => CommandType.World;
        public override string Command => "fullhouse";
        public override string Usage => "fullhouse";
        public override string Description => "Spawns all vanilla town NPCs";
        public override void Action(CommandCaller caller, string input, string[] args) {
            Player player = Main.LocalPlayer;
            List <Player> reqlist = new List<Player>();
            reqlist.Add(player);
            Predicate<Player> Nurse = new Predicate<Player>(NpcRequisites.Nurse);
            Predicate<Player> DyeTrader = new Predicate<Player>(NpcRequisites.DyeTrader);
            Predicate<Player> ArmsDealer = new Predicate<Player>(NpcRequisites.ArmsDealer);
            Predicate<Player> Demolitionist = new Predicate<Player>(NpcRequisites.Demolitionist);
            Predicate<Player> Painter = new Predicate<Player>(NpcRequisites.Painter);
            Predicate<Player> PartyGirl = new Predicate<Player>(NpcRequisites.PartyGirl);
            List <int> town = new List <int> {NPCID.Guide};
            int newNPC = 0;
            if (NpcRequisites.Git) {
                town.Add(ModContent.NPCType<Npcs.Town.Git>());
            }
            if (NpcRequisites.dryad) {
                town.Add(NPCID.Dryad);
            }
            if (NpcRequisites.Clothier) {
                town.Add(NPCID.Clothier);
            }
            if (NpcRequisites.Mechanic) {
                town.Add(NPCID.Mechanic);
            }
            if (NpcRequisites.Tinkerer) {
                town.Add(NPCID.GoblinTinkerer);
            }
            if (NpcRequisites.WitchDoctor) {
                town.Add(NPCID.WitchDoctor);
            }
            if (NpcRequisites.Stylist) {
                town.Add(NPCID.Stylist);
            }
            if (NpcRequisites.Angler) {
                town.Add(NPCID.Angler);
            }
            if (NpcRequisites.Santa) {
                town.Add(NPCID.SantaClaus);
            }
            if (NpcRequisites.SteamPunker) {
                town.Add(NPCID.Steampunker);
            }
            if (NpcRequisites.Ciborg) {
                town.Add(NPCID.Cyborg);
            }
            if (NpcRequisites.TaxesCollector) {
                town.Add(NPCID.TaxCollector);
            }
            if (NpcRequisites.Pirate) {
                town.Add(NPCID.Pirate);
            }
            if (NpcRequisites.Wizard) {
                town.Add(NPCID.Wizard);
            }
            if (reqlist.Exists(Nurse)) {
                town.Add(NPCID.Nurse);
            }
            if (reqlist.Exists(DyeTrader)) {
                town.Add(NPCID.DyeTrader);
            }
            if (reqlist.Exists(ArmsDealer)) {
                town.Add(NPCID.ArmsDealer);
            }
            if(reqlist.Exists(Demolitionist)) {
                town.Add(NPCID.Demolitionist);
            }
            if (reqlist.Exists(Painter)) {
                town.Add(NPCID.Painter);
            }
            if (reqlist.Exists(PartyGirl)) {
                town.Add(NPCID.PartyGirl);
            }
            foreach (int id in town) {
                if(!NPC.AnyNPCs(id)){
                    newNPC =  NPC.NewNPC(Main.spawnTileX*16 ,Main.spawnTileY * 16, id);        //Set X and Y to the position you want to spawn the NPC at
                    if (newNPC == NPCID.PartyGirl) {
                        Main.NewText(Main.npc[newNPC].GivenName + " the " + Main.npc[newNPC].TypeName +  " has arrived!", 255,20,147);
                    }
                    else {
                        Main.NewText(Main.npc[newNPC].GivenName + "the " + Main.npc[newNPC].TypeName + " has arrived!", 50,50,200);
                    }
                }
            }
        }
    }
}