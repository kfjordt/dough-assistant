<template>
    <div class="card-button" @click="handleClick" @mouseout="setHovered(false)" @mouseover="setHovered(true)"
        @mousedown="setPressed(true)" @mouseup="setPressed(false)" :style="{
            backgroundColor: cardColor,
            color: props.style.text
        }">
        {{ props.text }}
    </div>
</template>

<script setup lang="ts">
import { ICardButtonColorScheme } from '../../models/style/ComponentStyles';
import { PropType, ref } from 'vue';
import { computed } from '@vue/reactivity';

const props = defineProps({
    text: {
        type: String,
        required: false
    },
    style: {
        type: Object as PropType<ICardButtonColorScheme>,
        required: true
    }
});

const isHovered = ref(false);
const isPressed = ref(false);
const cardColor = computed(() => {
    return isPressed.value ? props.style.press : isHovered.value ? props.style.hover : props.style.background
})

const setHovered = (hovered: boolean) => {
    isHovered.value = hovered;
    // setTooltip(hovered)
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
.card-button {
    height: 100%;
    width: 100%;
    border-radius: 4px;
    cursor: pointer;
}
</style>