﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvoTool.Models
{
    public class Player
    {
        public enum PlayStyle { None = 0, Goal_Poacher = 1, Dummy_Runner = 2, Fox_in_the_Box = 3, Prolific_Winger = 4, Classic_No___10 = 5, Hole_Player = 6, Box__To__Box = 7, Anchor_Man = 8, The_Destroyer = 9, Extra_Frontman = 10, Offensive_Full__Back = 11, Defensive_Full__Back = 12, Deep__Lying_Forward = 13, Creative_Playmaker = 14, Build_Up = 15, Offensive_Goalkeeper = 16, Defensive_Goalkeeper = 17, Roaming_Flank = 18, Cross_Specialist = 19, Orchestrator = 20, Full__back_Finisher = 21, Target_Man = 22 }
        public enum PlayerForm { Inconsistent = 0, Standard = 1, Unwavering = 2 }
        public enum WeakFoot { Slightly_Low = 0, Medium = 1, High = 2, Very_High = 3 }
        public enum InjuryRes { Low = 0, Medium = 1, High = 2 }
        public enum PlayerPosition { C = 0, B = 1, A = 2 }
        public enum PlayerRegisteredPosition { GK = 0, CB = 1, LB = 2, RB = 3, DMF = 4, CMF = 5, LMF = 6, AMF = 7, RMF = 8, LWF = 9, RWF = 10, SS = 11, CF = 12 }
        public Player(uint ID)
        {
            this.ID = ID;
        }

        public uint YouthPlayerID { get; set; }
        public uint OwnerClubID { get; set; }
        public uint ID { get; set; }
        public uint ClubID { get; set; }
        public uint FreeKickMotion { get; set; }
        public uint ContractDate { get; set; }
        public uint PlayingStyle { get; set; }
        public uint LoanContractExpiryDate { get; set; }
        public uint NationalTeamCaps { get; set; }
        public uint MarketValue { get; set; }
        public uint Height { get; set; }
        public uint UnknownBits1 { get; set; }
        public uint SetPieceTaking { get; set; }
        public uint GoalCelebration { get; set; }
        public ushort NationalityID1 { get; set; }
        public ushort NationalityID2 { get; set; }
        public uint CornerKickMotion { get; set; }
        public uint Weight { get; set; }
        public uint UnknownBits2 { get; set; }
        public uint UnknownBits3 { get; set; }
        public uint UnknownBits4 { get; set; }
        public uint DefensiveAwareness { get; set; }
        public uint KickingPower { get; set; }
        public uint LowPass { get; set; }
        public bool UnknownBit1 { get; set; }
        public bool UnknownBit2 { get; set; }
        public uint UnknownBits5 { get; set; }
        public uint UnknownBits6 { get; set; }
        public uint PlayableLB { get; set; }
        public uint Speed { get; set; }
        public uint GKCatching { get; set; }
        public uint Jump { get; set; }
        public uint Heading { get; set; }
        public uint BallControl { get; set; }
        public uint PlayableLMF { get; set; }
        public uint GKAwareness { get; set; }
        public uint GKParrying { get; set; }
        public uint GKReflexes { get; set; }
        public uint Tackling { get; set; }
        public uint GKReach { get; set; }
        public uint PlayableGK { get; set; }
        public uint OffensiveAwareness { get; set; }
        public uint Dribbling { get; set; }
        public uint Acceleration { get; set; }
        public uint Stamina { get; set; }
        public uint Curl { get; set; }
        public bool UnknownBit3 { get; set; }
        public bool UnknownBit4 { get; set; }
        public uint LoftedPass { get; set; }
        public uint Finishing { get; set; }
        public uint PhysicalContact { get; set; }
        public uint Aggression { get; set; }
        public uint Balance { get; set; }
        public uint WeakFootUsage { get; set; }
        public uint RegisteredPosition { get; set; }
        public uint RunningArmMovement { get; set; }
        public uint DribblingArmMovement { get; set; }
        public uint TightPossession { get; set; }
        public uint DefensiveEngangement { get; set; }
        public uint Age { get; set; }
        public uint PlayableRB { get; set; }
        public uint PlayableLWF { get; set; }
        public uint PlayableCF { get; set; }
        public uint PlayableCB { get; set; }
        public uint Form { get; set; }
        public uint PlayableAMF { get; set; }
        public uint WeakFootAccuracy { get; set; }
        public uint PlayableRMF { get; set; }
        public uint InjuryResistance { get; set; }
        public uint PlayableCMF { get; set; }
        public uint UnknownBits7 { get; set; }
        public uint RunningHunching { get; set; }
        public uint DribblingHunching { get; set; }
        public uint PenaltyKickMotion { get; set; }
        public bool SlidingTackle { get; set; }
        public bool GKPenaltySaver { get; set; }
        public bool PenaltySpecialist { get; set; }
        public bool SoleControl { get; set; }
        public bool RisingShots { get; set; }
        public bool BallonDorWinner { get; set; }
        public bool MarseilleTurn { get; set; }
        public bool GKHighPunt { get; set; }
        public bool HeadingSkills { get; set; }
        public bool OutsideCurler { get; set; }
        public bool Captanincy { get; set; }
        public bool Gamasmanship { get; set; }
        public bool GkLowPunt { get; set; }
        public bool TrickSter { get; set; }
        public bool LowLoftedPass { get; set; }
        public bool ThroughPassing { get; set; }
        public bool FightingSpirit { get; set; }
        public bool FlipFlap { get; set; }
        public bool WeightedPass { get; set; }
        public bool AerialSuperiority { get; set; }
        public bool PinpointCrossing { get; set; }
        public bool Sombrero { get; set; }
        public bool EarlyCross { get; set; }
        public bool ChopTurn { get; set; }
        public uint DribblingMotion { get; set; }
        public uint PlayableSS { get; set; }
        public uint PlayableRWF { get; set; }
        public uint PlayableDMF { get; set; }
        public bool UnknownBit5 { get; set; }
        public bool StrongerHand { get; set; }
        public bool MazingRun { get; set; }
        public bool UnknownBit6 { get; set; }
        public bool LongBallExpert { get; set; }
        public bool AcrobaticClear { get; set; }
        public bool LongRangeCurler { get; set; }
        public bool SpeedingBullet { get; set; }
        public bool Blocker { get; set; }
        public bool ScotchMove { get; set; }
        public bool AcrobaticFinishing { get; set; }
        public bool DoubleTouch { get; set; }
        public bool GKLongThrow { get; set; }
        public bool LongThrow { get; set; }
        public bool ScissorsFeint { get; set; }
        public bool LongRangeShooting { get; set; }
        public bool TrackBack { get; set; }
        public bool SuperSub { get; set; }
        public bool Rabona { get; set; }
        public bool DippingShot { get; set; }
        public bool StroongerFoot { get; set; }
        public bool KnuckleShot { get; set; }
        public bool NoLookPass { get; set; }
        public bool FirstTimeShot { get; set; }
        public bool IncisiveRun { get; set; }
        public bool UnknownBit7 { get; set; }
        public bool LongRanger { get; set; }
        public bool OneTouchPass { get; set; }
        public bool ChipShotControl { get; set; }
        public bool HellTrick { get; set; }
        public bool ManMarking { get; set; }
        public bool Interception { get; set; }
        public string JapaneseName { get; set; }
        public string ShirtName { get; set; }
        public string ChineseName { get; set; }
        public string ClubShirtName { get; set; }
        public string Name { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
