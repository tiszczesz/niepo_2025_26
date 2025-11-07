
type Props = {
  label: string;
  min: number;
  max: number;
  startValue?: number;
  handleOnChange: (value: number) => void;
}

const MyRange = (props: Props) => {
  return (
    <div>
      <label>{props.label}</label>
      <input type="range" min={props.min} max={props.max} value={props.startValue}
      onChange={(e) => props.handleOnChange(Number(e.target.value))} />
    </div>
  )
}

export default MyRange  