using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentManager : MonoBehaviour
{
    #region Singleton
    public static EquipmentManager instance;

    void Awake()
    {
        instance = this;
    }
    #endregion

    public SkinnedMeshRenderer targetMesh;
    public Transform sword;
    public Transform headband;
    public Transform chestplate;
    public Transform arms;
    public Transform legs;
    public AudioSource equipSFX;
    public AudioSource unequipSFX;

    Equipment[] currentEquipment;
    SkinnedMeshRenderer[] currentMeshes;

    public delegate void OnEquipmentChanged(Equipment newItem, Equipment oldItem);
    public event OnEquipmentChanged onEquipmentChanged;

    Inventory inventory;

    void Start()
    {
        inventory = Inventory.instance;

        int numSlots = System.Enum.GetNames(typeof(EquipmentSlot)).Length;
        currentEquipment = new Equipment[numSlots];
        currentMeshes = new SkinnedMeshRenderer[numSlots];
    }

    public void Equip(Equipment newItem)
    {
        Equipment oldItem = null;

        // Find out what slot the item fits in
        // and put it there.
        int slotIndex = (int)newItem.equipSlot;

        // If there was already an item in the slot
        // make sure to put it back in the inventory
        if (currentEquipment[slotIndex] != null)
        {
            Unequip(slotIndex);
        }

        // An item has been equipped so we trigger the callback
        if (onEquipmentChanged != null)
            onEquipmentChanged.Invoke(newItem, oldItem);

        currentEquipment[slotIndex] = newItem;
        Debug.Log(newItem.name + " equipped!");

        if (newItem.equipSlot != EquipmentSlot.Weapon)
        {
            equipSFX.Play();
        }

        if (newItem.mesh)
        {
            SkinnedMeshRenderer newMesh = Instantiate(newItem.mesh) as SkinnedMeshRenderer;

            if (newItem != null && newItem.equipSlot == EquipmentSlot.Weapon)
            {
                newMesh.transform.parent = targetMesh.transform;
                newMesh.bones = targetMesh.bones;
                newMesh.rootBone = sword;
            }
            else if (newItem != null && newItem.equipSlot == EquipmentSlot.Chest)
            {
                newMesh.transform.parent = targetMesh.transform;
                newMesh.bones = targetMesh.bones;
                newMesh.rootBone = chestplate;
            }
            else if (newItem != null && newItem.equipSlot == EquipmentSlot.Arms)
            {
                newMesh.transform.parent = targetMesh.transform;
                newMesh.bones = targetMesh.bones;
                newMesh.rootBone = arms;
            }
            else if (newItem != null && newItem.equipSlot == EquipmentSlot.Legs)
            {
                newMesh.transform.parent = targetMesh.transform;
                newMesh.bones = targetMesh.bones;
                newMesh.rootBone = legs;
            }
            else if (newItem != null && (newItem.equipSlot == EquipmentSlot.Headband || newItem.equipSlot == EquipmentSlot.Shades || newItem.equipSlot == EquipmentSlot.Crown))
            {

                newMesh.transform.parent = targetMesh.transform;
                newMesh.bones = targetMesh.bones;
                newMesh.rootBone = headband;
            }
            else
            {
                newMesh.transform.parent = targetMesh.transform;
                newMesh.bones = targetMesh.bones;
                newMesh.rootBone = targetMesh.rootBone;
            }
            currentMeshes[slotIndex] = newMesh;
        }
    }

    public void Unequip(int slotIndex)
    {
        if (slotIndex != (int)EquipmentSlot.Weapon)
        {
            unequipSFX.Play();
        }

        Equipment oldItem = currentEquipment[slotIndex];
        if (oldItem != null)
        {
            if (currentMeshes[slotIndex] != null)
            {
                Destroy(currentMeshes[slotIndex].gameObject);
            }

            inventory.Add(oldItem);
            currentEquipment[slotIndex] = null;

            if (onEquipmentChanged != null)
            {
                onEquipmentChanged.Invoke(null, oldItem);
            }
        }
    }

    public void UnequipAll()
    {
        for (int i = 0; i < currentEquipment.Length; i++)
        {
            Unequip(i);
        }
    }

    public bool hasWeapon()
    {
        return currentEquipment[(int)EquipmentSlot.Weapon] != null;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.U))
            UnequipAll();
    }
}
