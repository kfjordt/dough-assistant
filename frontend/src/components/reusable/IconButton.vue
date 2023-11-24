<template>
    <div ref="iconButton" class="icon-button" @click="handleClick" @mouseout="setHovered(false)"
        @mouseover="setHovered(true)" @mousedown="setPressed(true)" @mouseup="setPressed(false)" :style="{
            backgroundColor: iconBgColor,
        }">
        <IconCard :icon="iconToUse" :isSpinning="false" :iconColor="iconTextColor" />
    </div>
</template>
  
<script setup lang="ts">
import { PropType, ref } from 'vue';
import IconCard from "./IconCard.vue"
import { Icons } from '../../models/icons/Icons';
import { IIconButtonColorScheme } from '../../models/style/ComponentStyles';
import { computed } from '@vue/reactivity';

const props = defineProps({
    icon: {
        type: Number as PropType<Icons>,
        required: true
    },
    style: {
        type: Object as PropType<IIconButtonColorScheme>,
        required: true
    }
});

const isHovered = ref(false);
const isPressed = ref(false);

const iconToUse = computed(() => {
    return props.icon
})

const iconBgColor = computed(() => {
    return isPressed.value ? props.style.press : isHovered.value ? props.style.hover : props.style.background
})

const iconTextColor = computed(() => {
    return props.style.icon
})

const setHovered = (hovered: boolean) => {
    isHovered.value = hovered;
};

const setPressed = (pressed: boolean) => {
    isPressed.value = pressed;
};

const emit = defineEmits(['click']);
const handleClick = () => {
    emit('click');
};
</script>
  
<style scoped>
.icon-button {
    display: inline-block;
    cursor: pointer;
    border-radius: 4px;
}
</style>
  