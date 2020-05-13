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
    public Transform chestplate;

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
        int slotIndex = (int)newItem.equipSlot;

        Equipment oldItem = currentEquipment[slotIndex];
        if (oldItem != null)
        {
            inventory.Add(oldItem);
        }

        if (onEquipmentChanged != null)
        {
            onEquipmentChanged.Invoke(newItem, oldItem);
        }

        currentEquipment[slotIndex] = newItem;
        SkinnedMeshRenderer newMesh = Instantiate(newItem.mesh) as SkinnedMeshRenderer;

        if (newItem != null && newItem.equipSlot == EquipmentSlot.Weapon)
        {
            newMesh.rootBone = sword;
        }
        // else if (newItem != null && newItem.equipSlot == EquipmentSlot.Chest)
        // {
        //     newMesh.rootBone = chestplate;
        // }
        else
        {
            newMesh.transform.parent = targetMesh.transform;
            newMesh.bones = targetMesh.bones;
            newMesh.rootBone = targetMesh.rootBone;
        }
        currentMeshes[slotIndex] = newMesh;
    }

    public void Unequip(int slotIndex)
    {
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

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.U))
            UnequipAll();
    }
}
