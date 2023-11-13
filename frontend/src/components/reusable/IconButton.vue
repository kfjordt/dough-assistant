<template>
    <div ref="iconButton" class="icon-button" :style="{ backgroundColor: bgColor }" @click="handleClick"
        @mousedown="setPressed(true)" @mouseup="setPressed(false)" @mouseout="setHovered(false)"
        @mouseover="setHovered(true)">
        <Icon :color="props.elementStyle.color" :icon="props.icon" :isSpinning="false" />
    </div>
</template>
  
<script setup lang="ts">
import { PropType, ref } from 'vue';
import { IInteractableElement } from '../../models/style/IInteractableElement';
import { computed } from '@vue/reactivity';
import Icon from "./Icon.vue"
import { Icons } from '../../models/icons/Icons';
import store from '../../store/store';
import { Tooltip } from '../../store/TooltipState';
import { HtmlBoundingBox } from '../../models/geometry/HtmlBoundingBox';
import { Point } from '../../models/geometry/Points';

const props = defineProps({
    icon: {
        type: Number as PropType<Icons>,
        required: true
    },
    elementStyle: {
        type: Object as PropType<IInteractableElement>,
        required: true
    },
    tooltip: {
        type: Object as PropType<Tooltip>,
        required: false
    }
});

const isHovered = ref(false);
const isPressed = ref(false)

const setHovered = (hovered: boolean) => {
    isHovered.value = hovered;
    setTooltip(hovered)
};

const setPressed = (pressed: boolean) => {
    isPressed.value = pressed
}

const emit = defineEmits(['click']);
const handleClick = () => {
    emit('click');
};

const bgColor = computed(() => {
    if (isPressed.value) {
        return props.elementStyle.pressColor.toHex()
    }

    if (isHovered.value) {
        return props.elementStyle.hoverColor.toHex();
    } else {
        return props.elementStyle.backgroundColor.toHex();
    }
});

const iconButton = ref<HTMLDivElement | null>(null);

const setTooltip = (set: boolean) => {
    if (set && props.tooltip) {
        const clientRect = iconButton.value.getBoundingClientRect()
        store.actions.setTooltip(
            props.tooltip,
            new HtmlBoundingBox(
                new Point(clientRect.x, clientRect.y + clientRect.height),
                clientRect.height,
                clientRect.width
            )
        )
    } else {
        store.actions.closeTooltip()
    }
}

</script>
  
<style scoped>
.icon-button {
    display: inline-block;
    cursor: pointer;
    border-radius: 5px;
}
</style>
  