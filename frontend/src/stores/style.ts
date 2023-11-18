import { computed, ref } from 'vue';
import { defineStore } from 'pinia';
import { getSectionStyles } from '../models/style/SectionStyles';
import { getPalette, ColorPalette } from '../models/style/ColorPalette';
import { ColorWrapper } from '../models/style/ColorWrapper';

export const useStyleStore = defineStore('style', () => {
    const currentMode = ref<"light" | "dark">("dark");

    const sectionStyles = computed(() => {
        const palette = currentMode.value === "dark"
            ? new ColorPalette(
                ColorWrapper.fromRgb(0, 0, 0),
                ColorWrapper.fromRgb(255, 255, 255),
            )
            : new ColorPalette(
                ColorWrapper.fromRgb(255, 255, 255),
                ColorWrapper.fromRgb(0, 0, 0),
            )

        return getSectionStyles(palette)
    })

    const toggleDarkMode = () => {
        currentMode.value = currentMode.value === "dark" ? "light" : "dark"
    }

    return {
        currentMode,
        sectionStyles,
        toggleDarkMode
    };
});