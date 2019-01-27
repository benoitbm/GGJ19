/////////////////////////////////////////////////////////////////////////////////////////////////////
//
// Audiokinetic Wwise generated include file. Do not edit.
//
/////////////////////////////////////////////////////////////////////////////////////////////////////

#ifndef __WWISE_IDS_H__
#define __WWISE_IDS_H__

#include <AK/SoundEngine/Common/AkTypes.h>

namespace AK
{
    namespace EVENTS
    {
        static const AkUniqueID AMBIENCE_START = 3908818592U;
        static const AkUniqueID CAR_START = 2744306108U;
        static const AkUniqueID CAR_STOP = 1465464336U;
        static const AkUniqueID LOSTBATTERY = 3613384186U;
        static const AkUniqueID MOVEMENT_STEPPLAYER = 1471192828U;
        static const AkUniqueID MOVEMENT_STEPPLAYER_STOP = 1156346507U;
        static const AkUniqueID TAKEPHONE_IN = 3848997754U;
        static const AkUniqueID TAKEPHONE_OUT = 2625436021U;
        static const AkUniqueID ZOOMPHONEIN = 2780459649U;
        static const AkUniqueID ZOOMPHONEOUT = 2055070848U;
    } // namespace EVENTS

    namespace SWITCHES
    {
        namespace BATTERY_DEAD
        {
            static const AkUniqueID GROUP = 1226663785U;

            namespace SWITCH
            {
                static const AkUniqueID ALIVE = 655265632U;
                static const AkUniqueID DEAD = 2044049779U;
            } // namespace SWITCH
        } // namespace BATTERY_DEAD

        namespace CAR_VARIATION
        {
            static const AkUniqueID GROUP = 312891615U;

            namespace SWITCH
            {
                static const AkUniqueID CAR1 = 4189504182U;
                static const AkUniqueID CAR2 = 4189504181U;
                static const AkUniqueID CAR3 = 4189504180U;
            } // namespace SWITCH
        } // namespace CAR_VARIATION

    } // namespace SWITCHES

    namespace GAME_PARAMETERS
    {
        static const AkUniqueID BATTERY_LIFE = 2337050305U;
        static const AkUniqueID CAR_ENGINE_PITCH = 724758105U;
        static const AkUniqueID CAR_VARIATION = 312891615U;
    } // namespace GAME_PARAMETERS

    namespace BANKS
    {
        static const AkUniqueID INIT = 1355168291U;
        static const AkUniqueID MAINBANK = 2880737896U;
    } // namespace BANKS

    namespace BUSSES
    {
        static const AkUniqueID MASTER_AUDIO_BUS = 3803692087U;
    } // namespace BUSSES

    namespace AUX_BUSSES
    {
        static const AkUniqueID REVERB = 348963605U;
    } // namespace AUX_BUSSES

    namespace AUDIO_DEVICES
    {
        static const AkUniqueID NO_OUTPUT = 2317455096U;
        static const AkUniqueID SYSTEM = 3859886410U;
    } // namespace AUDIO_DEVICES

}// namespace AK

#endif // __WWISE_IDS_H__
