<template>
    <div v-if="tooltipData.isTooltipLoaded" :style="getStyle()" class="tooltip">
        <span class="tooltip-main-text">{{ tooltipData.tooltip.content }}</span>
        <span class="tooltip-shortcut-text">{{ tooltipData.tooltip.shortcut }}</span>
    </div>
</template>

<script setup lang="ts">
import { computed } from '@vue/reactivity';
import { Anchor } from '../../models/geometry/Anchor';
import { ref } from 'vue';
import store from '../../store/store';

const tooltipData = computed(() => {
    return store.state.tooltipState
});

const getStyle = () => {
    return {
        ...getPosition(),
        backgroundColor: tooltipData.value.tooltip.style.backgroundColor.toHex(),
        color: tooltipData.value.tooltip.style.color.toHex()
    }
}

const getPosition = () => {
    const anchor = tooltipData.value.tooltip.anchor;
    const bb = tooltipData.value.anchorElement;

    const anchorPoint = bb.getAnchorPoint(anchor);

    const distance = 5

    let position = {
        top: "",
        bottom: "",
        right: "",
        left: ""
    }

    switch (anchor) {
        case Anchor.North:
            position.left = `${(anchorPoint.x / window.innerWidth) * 100}%`;
            position.bottom = `calc(100% - ${(anchorPoint.y / window.innerHeight) * 100}% + ${distance}px)`;
            break;

        case Anchor.Northeast:
            position.right = `calc(100% - ${(anchorPoint.x / window.innerWidth) * 100 % - distance}px)`;
            position.bottom = `calc(100% - ${(anchorPoint.y / window.innerHeight) * 100}%)`;
            break;

        case Anchor.East:
            position.left = `${(anchorPoint.x / window.innerWidth) * 100}%`;
            position.bottom = `${(anchorPoint.y / window.innerHeight) * 100}%`;
            break;

        case Anchor.Southeast:
            position.right = `calc(100vw - ${anchorPoint.x}px)`;
            position.top = `${anchorPoint.y + distance}px`;
            break;

        case Anchor.South:
            position.left = `${anchorPoint.x}px`;
            position.top = `${anchorPoint.y}px`;
            break;

        case Anchor.Southwest:
            position.left = `${anchorPoint.x}px`;
            position.top = `${anchorPoint.y}px`;
            break;

        case Anchor.West:
            position.right = `calc(100vw - ${anchorPoint.x}px)`;
            position.top = `${anchorPoint.y}px`;
            break;

        case Anchor.Northwest:
            position.bottom = `calc(100vh - ${anchorPoint.y}px)`;
            position.left = `${anchorPoint.x}px`;
            break;

        default:
            break;
    }

    return position;
};

</script>

<style scoped>
.tooltip {
    position: absolute;
    padding: 10px;
    border-radius: 5px;
    display: flex;
    flex-direction: column;
    align-items: center;
    box-shadow: 0 0 2px rgba(0, 0, 0, 0.8);

}

.tooltip-main-text {
    font-size: small;
}

.tooltip-shortcut-text {
    font-size: x-small;
}
</style>