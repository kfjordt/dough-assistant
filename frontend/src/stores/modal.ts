import { computed, ref } from 'vue';
import { defineStore } from 'pinia';
import { getSectionStyles } from '../models/style/SectionStyles';
import { getPalette } from '../models/style/ColorPalette';

export const useModalStore = defineStore('modal', () => {

    // clearTooltipTimeout() {
    //     const timeoutId = (this as StoreState).tooltipState.tooltipTimeoutId
    //     if (timeoutId !== null) {
    //         clearTimeout(timeoutId)
    //     }
    // },
    // setTooltip(tooltip: Tooltip, elementBb: HtmlBoundingBox) {
    //     const tooltipTimeoutId = setTimeout(() => {
    //         (this as StoreState).tooltipState = {
    //             isTooltipLoaded: true,
    //             tooltip: tooltip,
    //             anchorElement: elementBb,
    //             tooltipTimeoutId: null
    //         }
    //     }, 500)

    // },
    // closeTooltip() {
    //     (this as StoreState).tooltipState = {
    //         isTooltipLoaded: false,
    //         tooltipTimeoutId: null
    //     };
    // },

    return {
        // currentMode,
        // sectionStyles
    };
});
