// GENERATED AUTOMATICALLY FROM 'Assets/MyGrid/Presets/MyInputActions.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @MyInputActions : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @MyInputActions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""MyInputActions"",
    ""maps"": [
        {
            ""name"": ""playerMap"",
            ""id"": ""7ac87063-8007-4587-9c81-85b63623ecd6"",
            ""actions"": [
                {
                    ""name"": ""MoveCursor"",
                    ""type"": ""Value"",
                    ""id"": ""6aec3c7c-52c3-4b4c-b445-f01569869f9d"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MoveButton"",
                    ""type"": ""Button"",
                    ""id"": ""de687532-9606-4749-a801-43bc31becf01"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""NextUnit"",
                    ""type"": ""Button"",
                    ""id"": ""ba227290-91f8-4ce3-944e-2f2753f06f42"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""PreviousUnit"",
                    ""type"": ""Button"",
                    ""id"": ""e9309f5f-7d46-48c6-a2d9-1c69beada243"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""7208fe7e-59d9-4358-bf4b-8ea77fa5a82b"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""New control scheme"",
                    ""action"": ""MoveCursor"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""add118e1-8bb8-4f4d-9a93-0edfcf31a10e"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""New control scheme"",
                    ""action"": ""MoveButton"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6b5586fe-8868-422c-b2b1-a09d95bdd5bb"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""NextUnit"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""72373644-8469-4623-bf64-333be7629359"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PreviousUnit"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""New control scheme"",
            ""bindingGroup"": ""New control scheme"",
            ""devices"": []
        }
    ]
}");
        // playerMap
        m_playerMap = asset.FindActionMap("playerMap", throwIfNotFound: true);
        m_playerMap_MoveCursor = m_playerMap.FindAction("MoveCursor", throwIfNotFound: true);
        m_playerMap_MoveButton = m_playerMap.FindAction("MoveButton", throwIfNotFound: true);
        m_playerMap_NextUnit = m_playerMap.FindAction("NextUnit", throwIfNotFound: true);
        m_playerMap_PreviousUnit = m_playerMap.FindAction("PreviousUnit", throwIfNotFound: true);
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

    // playerMap
    private readonly InputActionMap m_playerMap;
    private IPlayerMapActions m_PlayerMapActionsCallbackInterface;
    private readonly InputAction m_playerMap_MoveCursor;
    private readonly InputAction m_playerMap_MoveButton;
    private readonly InputAction m_playerMap_NextUnit;
    private readonly InputAction m_playerMap_PreviousUnit;
    public struct PlayerMapActions
    {
        private @MyInputActions m_Wrapper;
        public PlayerMapActions(@MyInputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @MoveCursor => m_Wrapper.m_playerMap_MoveCursor;
        public InputAction @MoveButton => m_Wrapper.m_playerMap_MoveButton;
        public InputAction @NextUnit => m_Wrapper.m_playerMap_NextUnit;
        public InputAction @PreviousUnit => m_Wrapper.m_playerMap_PreviousUnit;
        public InputActionMap Get() { return m_Wrapper.m_playerMap; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerMapActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerMapActions instance)
        {
            if (m_Wrapper.m_PlayerMapActionsCallbackInterface != null)
            {
                @MoveCursor.started -= m_Wrapper.m_PlayerMapActionsCallbackInterface.OnMoveCursor;
                @MoveCursor.performed -= m_Wrapper.m_PlayerMapActionsCallbackInterface.OnMoveCursor;
                @MoveCursor.canceled -= m_Wrapper.m_PlayerMapActionsCallbackInterface.OnMoveCursor;
                @MoveButton.started -= m_Wrapper.m_PlayerMapActionsCallbackInterface.OnMoveButton;
                @MoveButton.performed -= m_Wrapper.m_PlayerMapActionsCallbackInterface.OnMoveButton;
                @MoveButton.canceled -= m_Wrapper.m_PlayerMapActionsCallbackInterface.OnMoveButton;
                @NextUnit.started -= m_Wrapper.m_PlayerMapActionsCallbackInterface.OnNextUnit;
                @NextUnit.performed -= m_Wrapper.m_PlayerMapActionsCallbackInterface.OnNextUnit;
                @NextUnit.canceled -= m_Wrapper.m_PlayerMapActionsCallbackInterface.OnNextUnit;
                @PreviousUnit.started -= m_Wrapper.m_PlayerMapActionsCallbackInterface.OnPreviousUnit;
                @PreviousUnit.performed -= m_Wrapper.m_PlayerMapActionsCallbackInterface.OnPreviousUnit;
                @PreviousUnit.canceled -= m_Wrapper.m_PlayerMapActionsCallbackInterface.OnPreviousUnit;
            }
            m_Wrapper.m_PlayerMapActionsCallbackInterface = instance;
            if (instance != null)
            {
                @MoveCursor.started += instance.OnMoveCursor;
                @MoveCursor.performed += instance.OnMoveCursor;
                @MoveCursor.canceled += instance.OnMoveCursor;
                @MoveButton.started += instance.OnMoveButton;
                @MoveButton.performed += instance.OnMoveButton;
                @MoveButton.canceled += instance.OnMoveButton;
                @NextUnit.started += instance.OnNextUnit;
                @NextUnit.performed += instance.OnNextUnit;
                @NextUnit.canceled += instance.OnNextUnit;
                @PreviousUnit.started += instance.OnPreviousUnit;
                @PreviousUnit.performed += instance.OnPreviousUnit;
                @PreviousUnit.canceled += instance.OnPreviousUnit;
            }
        }
    }
    public PlayerMapActions @playerMap => new PlayerMapActions(this);
    private int m_NewcontrolschemeSchemeIndex = -1;
    public InputControlScheme NewcontrolschemeScheme
    {
        get
        {
            if (m_NewcontrolschemeSchemeIndex == -1) m_NewcontrolschemeSchemeIndex = asset.FindControlSchemeIndex("New control scheme");
            return asset.controlSchemes[m_NewcontrolschemeSchemeIndex];
        }
    }
    public interface IPlayerMapActions
    {
        void OnMoveCursor(InputAction.CallbackContext context);
        void OnMoveButton(InputAction.CallbackContext context);
        void OnNextUnit(InputAction.CallbackContext context);
        void OnPreviousUnit(InputAction.CallbackContext context);
    }
}
