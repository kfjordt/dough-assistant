<template>
    <v-icon :fill="$props.color.toHex()" speed="slow" class="icon" :name="iconAsStr" :animation="animation" />
</template>

<script setup lang="ts">
import { PropType } from 'vue';
import { Icons, getIconAsStr } from '../../models/icons/Icons';
import { ColorWrapper } from '../../models/style/ColorWrapper';

const props = defineProps({
    icon: {
        type: Number as PropType<Icons>,
        required: true
    },
    color: {
        type: Object as PropType<ColorWrapper>,
        required: true
    },
    isSpinning: {
        type: Boolean
    }
});

const iconAsStr = getIconAsStr(props.icon)
const animation = props.isSpinning ? "spin" : undefined
</script>

<style scoped>
.icon {
    padding: 8px
}
</style>