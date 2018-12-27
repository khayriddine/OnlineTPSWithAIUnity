using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEventHandler : MonoBehaviour {

	public delegate void HealthEventHandler(int amount);
	public delegate void ArmorEventHandler(int amount);
	public delegate void WeaponEventHandler(int amount);


	public event HealthEventHandler HealthDeductEvent;
	public event HealthEventHandler HealthRegenEvent;

	public event ArmorEventHandler ArmorDeductEvent;
	public event ArmorEventHandler ArmorRegenEvent;

	public event WeaponEventHandler AmmoInClipDeductEvent;
	public event WeaponEventHandler AmmoInClipRechargeEvent;

	public event WeaponEventHandler GreandeDeductEvent;
	public event WeaponEventHandler GreandeRechargeEvent;

	public void CallHealthDeductEvent(int amount){
		if (HealthDeductEvent != null) {
			HealthDeductEvent (amount);
		}
	}
	public void CallHealthRegenEvent(int amount){
		if (HealthRegenEvent != null) {
			HealthRegenEvent (amount);
		}
	}
	public void CallArmorDeductEvent(int amount){
		if (ArmorDeductEvent != null) {
			ArmorDeductEvent (amount);
		}
	}
	public void CallArmorRegenEvent(int amount){
		if (ArmorRegenEvent != null) {
			ArmorRegenEvent (amount);
		}
	}
	public void CallAmmoInClipDeductEvent(int amount){
		if (AmmoInClipDeductEvent != null) {
			AmmoInClipDeductEvent (amount);
		}
	}
	public void CallAmmoInClipRechargeEvent(int amount){
		if (AmmoInClipRechargeEvent != null) {
			AmmoInClipRechargeEvent (amount);
		}
	}
	public void CallGreandeDeductEvent(int amount){
		if (GreandeDeductEvent != null) {
			GreandeDeductEvent (amount);
		}
	}
	public void CallGreandeRechargeEvent(int amount){
		if (GreandeRechargeEvent != null) {
			GreandeRechargeEvent (amount);
		}
	}




}
