//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.3.0
//     from Assets/Jump Game Project/Scripts/InputSystems/User Controls.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @UserControls : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @UserControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""User Controls"",
    ""maps"": [
        {
            ""name"": ""Player action map"",
            ""id"": ""1fe8363f-3a3d-4451-ad58-9a95667e431b"",
            ""actions"": [
                {
                    ""name"": ""PrimaryContact"",
                    ""type"": ""PassThrough"",
                    ""id"": ""147c3ecb-c847-4afb-b9f5-6c73357be85a"",
                    ""expectedControlType"": ""Touch"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""PrimaryPosition"",
                    ""type"": ""PassThrough"",
                    ""id"": ""2612092c-ebd2-4a2f-b7b2-81bacbcb9865"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""373ae386-849b-486a-bc36-6622ab54b6ef"",
                    ""path"": ""<Pointer>/primaryTouch"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PrimaryContact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""dfd323f9-1d13-42a7-879e-8cf4453f7e90"",
                    ""path"": ""<Pointer>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PrimaryPosition"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Player action map
        m_Playeractionmap = asset.FindActionMap("Player action map", throwIfNotFound: true);
        m_Playeractionmap_PrimaryContact = m_Playeractionmap.FindAction("PrimaryContact", throwIfNotFound: true);
        m_Playeractionmap_PrimaryPosition = m_Playeractionmap.FindAction("PrimaryPosition", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }
    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }
    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // Player action map
    private readonly InputActionMap m_Playeractionmap;
    private IPlayeractionmapActions m_PlayeractionmapActionsCallbackInterface;
    private readonly InputAction m_Playeractionmap_PrimaryContact;
    private readonly InputAction m_Playeractionmap_PrimaryPosition;
    public struct PlayeractionmapActions
    {
        private @UserControls m_Wrapper;
        public PlayeractionmapActions(@UserControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @PrimaryContact => m_Wrapper.m_Playeractionmap_PrimaryContact;
        public InputAction @PrimaryPosition => m_Wrapper.m_Playeractionmap_PrimaryPosition;
        public InputActionMap Get() { return m_Wrapper.m_Playeractionmap; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayeractionmapActions set) { return set.Get(); }
        public void SetCallbacks(IPlayeractionmapActions instance)
        {
            if (m_Wrapper.m_PlayeractionmapActionsCallbackInterface != null)
            {
                @PrimaryContact.started -= m_Wrapper.m_PlayeractionmapActionsCallbackInterface.OnPrimaryContact;
                @PrimaryContact.performed -= m_Wrapper.m_PlayeractionmapActionsCallbackInterface.OnPrimaryContact;
                @PrimaryContact.canceled -= m_Wrapper.m_PlayeractionmapActionsCallbackInterface.OnPrimaryContact;
                @PrimaryPosition.started -= m_Wrapper.m_PlayeractionmapActionsCallbackInterface.OnPrimaryPosition;
                @PrimaryPosition.performed -= m_Wrapper.m_PlayeractionmapActionsCallbackInterface.OnPrimaryPosition;
                @PrimaryPosition.canceled -= m_Wrapper.m_PlayeractionmapActionsCallbackInterface.OnPrimaryPosition;
            }
            m_Wrapper.m_PlayeractionmapActionsCallbackInterface = instance;
            if (instance != null)
            {
                @PrimaryContact.started += instance.OnPrimaryContact;
                @PrimaryContact.performed += instance.OnPrimaryContact;
                @PrimaryContact.canceled += instance.OnPrimaryContact;
                @PrimaryPosition.started += instance.OnPrimaryPosition;
                @PrimaryPosition.performed += instance.OnPrimaryPosition;
                @PrimaryPosition.canceled += instance.OnPrimaryPosition;
            }
        }
    }
    public PlayeractionmapActions @Playeractionmap => new PlayeractionmapActions(this);
    public interface IPlayeractionmapActions
    {
        void OnPrimaryContact(InputAction.CallbackContext context);
        void OnPrimaryPosition(InputAction.CallbackContext context);
    }
}