<template>
    <v-icon :fill="$props.style.iconColor" speed="slow" class="icon" :name="iconAsStr" :animation="animation" />
</template>

<script setup lang="ts">
import { PropType } from 'vue';
import { Icons, getIconAsStr } from '../../models/icons/Icons';
import { ColorWrapper } from '../../models/style/ColorWrapper';
import { IIconStyle } from '../../models/style/ElementStyles';

const props = defineProps({
    icon: {
        type: Number as PropType<Icons>,
        required: true
    },
    isSpinning: {
        type: Boolean
    },
    style: {
        type: Object as PropType<IIconStyle>,
        required: true
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