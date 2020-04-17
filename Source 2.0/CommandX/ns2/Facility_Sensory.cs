﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Xml;
using Command_Core;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace ns2
{
	// Token: 0x02000AC0 RID: 2752
	public sealed class Facility_Sensory : ActiveUnit_Sensory
	{
		// Token: 0x060057EF RID: 22511 RVA: 0x00269E34 File Offset: 0x00268034
		public static Facility_Sensory Load(ref XmlNode xmlNode_0, ref Dictionary<string, Subject> dictionary_1, ref ActiveUnit activeUnit_1)
		{
			Facility_Sensory result = null;
			try
			{
				Facility_Sensory facility_Sensory = new Facility_Sensory(ref activeUnit_1);
				facility_Sensory.ParentPlatform = activeUnit_1;
				IEnumerator enumerator = xmlNode_0.ChildNodes.GetEnumerator();
				try
				{
					while (enumerator.MoveNext())
					{
						XmlNode xmlNode = (XmlNode)enumerator.Current;
						string name = xmlNode.Name;
						if (Operators.CompareString(name, "ObeysEMCON", false) != 0 && Operators.CompareString(name, "ObE", false) != 0)
						{
							if (Operators.CompareString(name, "ContactList", false) != 0 && Operators.CompareString(name, "ContactList_Local", false) != 0)
							{
								if (Operators.CompareString(name, "ContactList_OffGrid", false) != 0)
								{
									continue;
								}
								IEnumerator enumerator2 = xmlNode.ChildNodes.GetEnumerator();
								try
								{
									while (enumerator2.MoveNext())
									{
										XmlNode xmlNode2 = (XmlNode)enumerator2.Current;
										Contact contact = Contact.Load(ref xmlNode2, ref dictionary_1);
										facility_Sensory.ContactList_OffGrid.Add(contact.string_6, contact);
									}
									continue;
								}
								finally
								{
									if (enumerator2 is IDisposable)
									{
										(enumerator2 as IDisposable).Dispose();
									}
								}
							}
							IEnumerator enumerator3 = xmlNode.ChildNodes.GetEnumerator();
							try
							{
								while (enumerator3.MoveNext())
								{
									XmlNode xmlNode3 = (XmlNode)enumerator3.Current;
									string text = "";
									ActiveUnit_Sensory.ContactEntry value = ActiveUnit_Sensory.ContactEntry.Load(ref xmlNode3, ref dictionary_1, ref text);
									if (!Information.IsNothing(text) && !facility_Sensory.GetContactEntryDictionary().ContainsKey(text))
									{
										facility_Sensory.GetContactEntryDictionary().Add(text, value);
									}
								}
								continue;
							}
							finally
							{
								if (enumerator3 is IDisposable)
								{
									(enumerator3 as IDisposable).Dispose();
								}
							}
						}
						facility_Sensory.bObeysEMCON = Conversions.ToBoolean(xmlNode.InnerText);
					}
				}
				finally
				{
					if (enumerator is IDisposable)
					{
						(enumerator as IDisposable).Dispose();
					}
				}
				result = facility_Sensory;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2.Data.Add("Error at 100566", "");
				GameGeneral.LogException(ref ex2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				result = new Facility_Sensory(ref activeUnit_1);
				ProjectData.ClearProjectError();
			}
			return result;
		}

		// Token: 0x060057F0 RID: 22512 RVA: 0x00024AEC File Offset: 0x00022CEC
		public Facility_Sensory(ref ActiveUnit activeUnit_1) : base(ref activeUnit_1)
		{
		}

		// Token: 0x060057F1 RID: 22513 RVA: 0x0026A0B0 File Offset: 0x002682B0
		public override void ScheduleEMCONEvent(Sensor[] SensorArray_)
		{
			checked
			{
				try
				{
					Doctrine._IgnoreEMCONUnderAttack? ignoreEMCONUnderAttackDoctrine = this.ParentPlatform.m_Doctrine.GetIgnoreEMCONUnderAttackDoctrine(this.ParentPlatform.m_Scenario, false, false, false);
					byte? b = ignoreEMCONUnderAttackDoctrine.HasValue ? new byte?((byte)ignoreEMCONUnderAttackDoctrine.GetValueOrDefault()) : null;
					if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 1) : null).GetValueOrDefault() && this.ParentPlatform.GetAI().vmethod_9())
					{
						for (int i = 0; i < SensorArray_.Length; i++)
						{
							Sensor sensor = SensorArray_[i];
							if (sensor.IsActiveCapable())
							{
								sensor.TurnOn();
							}
						}
					}
					else
					{
						base.ScheduleEMCONEvent(SensorArray_);
					}
				}
				catch (Exception ex)
				{
					ProjectData.SetProjectError(ex);
					Exception ex2 = ex;
					ex2.Data.Add("Error at 100567", "");
					GameGeneral.LogException(ref ex2);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					ProjectData.ClearProjectError();
				}
			}
		}
	}
}
