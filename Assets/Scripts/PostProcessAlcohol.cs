using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PostProcessing;

public class PostProcessAlcohol : MonoBehaviour
{
    private UnityStandardAssets.Characters.FirstPerson.RigidbodyFirstPersonController player;
    [SerializeField] private PostProcessingProfile processProfile;
    [SerializeField] private float minValueSightReduced = 5.0f;
    [SerializeField] private float sightLossIntensifier = 10.0f;
    [SerializeField] private float bloomIntensifier = 2.0f;

    bool isPaused = false;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<UnityStandardAssets.Characters.FirstPerson.RigidbodyFirstPersonController>();
        //processProfile = GetComponent<PostProcessingBehaviour>().profile;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        float alcohol = player.AlcoholLevel;

        BloomModel bm = processProfile.bloom;
        BloomModel.Settings bmSet = bm.settings;
        bmSet.bloom.intensity = alcohol * bloomIntensifier;
        bm.settings = bmSet;
        processProfile.bloom = bm;
        //processProfile.GetSetting<Bloom>().intensity = intensityF;

        float vignetteIntendity = Mathf.Clamp((alcohol - minValueSightReduced) / sightLossIntensifier, 0.0f, 1.0f);
        VignetteModel vm = processProfile.vignette;
        VignetteModel.Settings vmSet = vm.settings;
        vmSet.intensity = vignetteIntendity;
        vm.settings = vmSet;
        processProfile.vignette = vm;

        processProfile.grain.enabled = isPaused;
        if (isPaused)
        {
            float val = 0.6f + Mathf.PingPong(Time.time, 0.2f);

            GrainModel gm = processProfile.grain;
            GrainModel.Settings gmSet = gm.settings;
            gmSet.intensity = val;
            gm.settings = gmSet;
            processProfile.grain = gm;
        }
    }
}
