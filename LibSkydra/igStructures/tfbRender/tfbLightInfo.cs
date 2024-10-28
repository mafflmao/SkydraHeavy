using System;

namespace LibSkydra
{
    public class tfbLightInfo : igNamedObject
    {
        [igIntMetaField(0xFF, IG_CORE_PLATFORM.DEFAULT, "_lightType", 0x00)]
        public int lightType;
        //[igVec4ucMetaField(0xFF, IG_CORE_PLATFORM.DEFAULT, "_diffuseColor", 0x00)]
        //public Vector4 diffuseColor;
        //[igVec3fMetaField(0xFF, IG_CORE_PLATFORM.DEFAULT, "_min", 0x00)]
        //public Vector3 min;
        //[igVec3fMetaField(0xFF, IG_CORE_PLATFORM.DEFAULT, "_max", 0x00)]
        //public Vector3 max;
        //[igFloatMetaField(0xFF, IG_CORE_PLATFORM.DEFAULT, "_intensity", 0x00)]
        //public igFloatMetaField intensity;
        //[igVec2fMetaField(0xFF, IG_CORE_PLATFORM.DEFAULT, "_attenuation", 0x00)]
        //public Vector2 attenuation;
        //[igFloatMetaField(0xFF, IG_CORE_PLATFORM.DEFAULT, "_boxAttenuation", 0x00)]
        //public float boxAttenuation;
        //[igFloatMetaField(0xFF, IG_CORE_PLATFORM.DEFAULT, "_boxAttenuationNear", 0x00)]
        //public float boxAttenuationNear;
        //[igFloatMetaField(0xFF, IG_CORE_PLATFORM.DEFAULT, "_xFalloff", 0x00)]
        //public float xFalloff;
        //[igFloatMetaField(0xFF, IG_CORE_PLATFORM.DEFAULT, "_yFalloff", 0x00)]
        //public float yFalloff;
        //[igFloatMetaField(0xFF, IG_CORE_PLATFORM.DEFAULT, "_wrap", 0x00)]
        //public float wrap;
        //[igStringMetaField(0xFF, IG_CORE_PLATFORM.DEFAULT, "_cookieTextureName", 0x00)]
        //public string cookieTextureName;
        //[igBoolMetaField(0xFF, IG_CORE_PLATFORM.DEFAULT, "_visible", 0x00)]
        //public bool visible;
        //[igBoolMetaField(0xFF, IG_CORE_PLATFORM.DEFAULT, "_cullable", 0x00)]
        //public bool cullable;
        //[igUnsignedIntMetaField(0xFF, IG_CORE_PLATFORM.DEFAULT, "_vizSet", 0x00)]
        //public int vizSet;
        //[igBoolMetaField(0xFF, IG_CORE_PLATFORM.DEFAULT, "_projectedTexture", 0x00)]
        //public bool projectedTexture;
        //[igObjectRefMetaField(0xFF, IG_CORE_PLATFORM.DEFAULT, "_animatableTextureDataInfo", 0x00)]
        //public igObject animatableTextureDataInfo;
        //[igObjectRefMetaField(0xFF, IG_CORE_PLATFORM.DEFAULT, "_uvAnimation", 0x00)]
        //public igObject uvAnimation;
        //[igHandleMetaField(0xFF, IG_CORE_PLATFORM.DEFAULT, "_imageHandle", 0x00)]
        //public igHandle imageHandle;
        //[igFloatMetaField(0xFF, IG_CORE_PLATFORM.DEFAULT, "_priority", 0x00)]
        //public float priority;
        //[igFloatMetaField(0xFF, IG_CORE_PLATFORM.DEFAULT, "_cutoffAngle", 0x00)]
        //public float cutoffAngle;
        //[igFloatMetaField(0xFF, IG_CORE_PLATFORM.DEFAULT, "_constantAttenuationCoeff", 0x00)]
        //public float constantAttenuationCoeff;
        //[igFloatMetaField(0xFF, IG_CORE_PLATFORM.DEFAULT, "_linearAttenuationCoeff", 0x00)]
        //public float linearAttenuationCoeff;
        //[igFloatMetaField(0xFF, IG_CORE_PLATFORM.DEFAULT, "_quadraticAttenuationCoeff", 0x00)]
        //public float quadraticAttenuationCoeff;
        //[igVec4ucMetaField(0xFF, IG_CORE_PLATFORM.DEFAULT, "_ambientColor", 0x00)]
        //public Vector4 ambientColor;
        //[igVec4ucMetaField(0xFF, IG_CORE_PLATFORM.DEFAULT, "_specularColor", 0x00)]
        //public Vector4 specularColor;
        //[igFloatMetaField(0xFF, IG_CORE_PLATFORM.DEFAULT, "_multiplier", 0x00)]
        //public float multiplier;
        //[igTStaticMetaField(0xFF, IG_CORE_PLATFORM.DEFAULT, "_interface", 0x00)]
        //public igObject _interface; // cant just use 'interface' rip
        //[igTStaticMetaField(0xFF, IG_CORE_PLATFORM.DEFAULT, "_lightInfos", 0x00)]
        //public igObject lightInfos;
        //[igTStaticMetaField(0xFF, IG_CORE_PLATFORM.DEFAULT, "_showVolumesInTool", 0x00)]
        //public igObject showVolumesInTool;
        // TO-DO: finish this object type, i just need the offsets iirc

        public tfbLightInfo(IGZ igz) : base(igz) { }
    }
}